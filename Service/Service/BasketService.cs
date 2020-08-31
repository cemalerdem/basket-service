using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.BaseException;
using Common.Command;
using Common.Query;
using Common.ViewModels;
using Data.Entity;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Service.Interfaces;

namespace Service.Service
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IBasketItemRepository _basketItemRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public BasketService(IBasketRepository basketRepository, IBasketItemRepository basketItemRepository,
            IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _basketRepository = basketRepository;
            _basketItemRepository = basketItemRepository;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<BasketDto> GenerateEmptyBasket()
        {
            var basket = new BasketView();
            basket.Handle();

            _basketRepository.Add(basket);
            await _unitOfWork.CommitAsync();

            return new BasketDto(basket.Id);
        }

        public async Task<BasketItemDto> GetBasketItems(GetBasketItemQuery query)
        {
            try
            {
                var basketItems = await _basketItemRepository.GetManyAsNoTrackingAsync(x => x.BasketId == query.BasketId);

                if (basketItems.Count == 0) return new BasketItemDto(query.BasketId);

                var products = await (from basket in _basketRepository.Table
                                                    join item in _basketItemRepository.Table on basket.Id equals item.BasketId
                                                    join product in _productRepository.Table on item.ItemId equals product.Id
                                                    select new ProductDto
                                                    {
                                                        Id = item.ItemId,
                                                        Name = product.Name,
                                                        Quantity = item.Quantity,
                                                        UnitPrice = product.UnitPrice
                                                    }).ToListAsync() ?? new List<ProductDto>();

                return new BasketItemDto(query.BasketId, products);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<BasketItemDto> AddItemToBasket(AddItemToBasketCommand command)
        {
            try
            {
                var isBasketExit = await _basketRepository.AnyAsync(x => x.Id == command.BasketId);

                if (!isBasketExit) throw new BasketException(ErrorCode.BasketNotFound, string.Format(ErrorMessageConstants.BasketNotFound, command.BasketId));

                var itemToAdd = await _productRepository.Table.FirstOrDefaultAsync(x => x.Id == command.ItemId);

                if (itemToAdd == null) throw new BasketException(ErrorCode.ItemNotFound, string.Format(ErrorMessageConstants.ItemNotFound, command.ItemId));

                if (itemToAdd.Quantity < command.Quantity) throw new BasketException(ErrorCode.OutOfStock, string.Format(ErrorMessageConstants.OutOfStock, itemToAdd.Quantity));

                _basketItemRepository.Add(new BasketItem
                {
                    Id = Guid.NewGuid(),
                    Quantity = command.Quantity,
                    BasketId = command.BasketId,
                    ItemId = command.ItemId,
                });
                
                itemToAdd.Quantity -= command.Quantity;
                _productRepository.Update(itemToAdd);
                
                await _unitOfWork.CommitAsync();

                return await GetBasketItems(new GetBasketItemQuery(command.BasketId));
               
            }
            catch (Exception e)
            {
                throw new BasketException(ErrorCode.InvalidOperation, ErrorMessageConstants.CanNotAddItem, e);
            }
        }

        public async Task<BasketItemDto> UpdateItemQuantity(UpdateItemQuantityCommand command)
        {
            try
            {
                var basketItem = await _basketItemRepository.Table.FirstOrDefaultAsync(x => x.BasketId == command.BasketId && x.ItemId == command.ItemId);

                if (basketItem == null) throw new BasketException(ErrorCode.ItemNotFound, string.Format(ErrorMessageConstants.ItemNotFound, command.ItemId));
                
                var product = await _productRepository.Table.FirstOrDefaultAsync(x => x.Id == command.ItemId);
                
                var updatedProductStock = UpdateProductStock(product, basketItem.Quantity, command.Quantity);
                
                if(updatedProductStock.Quantity <= 0) throw new BasketException(ErrorCode.OutOfStock, string.Format(ErrorMessageConstants.OutOfStock, updatedProductStock.Quantity));
                
                basketItem.Handle(command);
                
                _basketItemRepository.Update(basketItem);
                _productRepository.Update(updatedProductStock);
                await _unitOfWork.CommitAsync();

                return await GetBasketItems(new GetBasketItemQuery(command.BasketId));
            }
            catch (Exception e)
            {
                throw new BasketException(ErrorCode.InvalidOperation, ErrorMessageConstants.CanNotUpdateItem, e);
            }
        }

        public async Task<BasketItemDto> RemoveItemFromBasket(RemoveItemFromBasketCommand command)
        {
            try
            {
                var itemToDelete = await _basketItemRepository.Table.FirstOrDefaultAsync(x =>
                    x.BasketId == command.BasketId && x.ItemId == command.ItemId);

                if (itemToDelete == null) throw new BasketException(ErrorCode.ItemNotFound, string.Format(ErrorMessageConstants.ItemNotFound, command.ItemId));

                var product = await _productRepository.Table.FirstOrDefaultAsync(x => x.Id == command.ItemId);
                product.Quantity += itemToDelete.Quantity;
                
                _basketItemRepository.Delete(itemToDelete);
                _productRepository.Update(product);
                await _unitOfWork.CommitAsync();

                return await GetBasketItems(new GetBasketItemQuery(command.BasketId));
            }
            catch (Exception e)
            {
                throw new BasketException(ErrorCode.InvalidOperation, ErrorMessageConstants.CanNotRemoveItem, e);
            }
        }

        private ItemDetailView UpdateProductStock(ItemDetailView product, int existQuantity, int newQuantity)
        {
            if (existQuantity > newQuantity)
            {
                product.Quantity += (existQuantity - newQuantity);
            }
            else if(newQuantity > existQuantity)
            {
                product.Quantity -= (newQuantity - existQuantity);
            }
            return product;
        }
    }
}