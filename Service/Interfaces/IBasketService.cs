using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Command;
using Common.Query;
using Common.ViewModels;
using Data.Entity;

namespace Service.Interfaces
{
    public interface IBasketService
    {
        Task<BasketDto> GenerateEmptyBasket();
        Task<BasketItemDto> GetBasketItems(GetBasketItemQuery query);
        Task<BasketItemDto> AddItemToBasket(AddItemToBasketCommand command);
        Task<BasketItemDto> UpdateItemQuantity(UpdateItemQuantityCommand command);
        Task<BasketItemDto> RemoveItemFromBasket(RemoveItemFromBasketCommand command);
    }
}