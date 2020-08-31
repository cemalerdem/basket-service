using System;
using System.Threading.Tasks;
using Common.Command;
using Common.Query;
using Common.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpGet]
        [Route("GenerateBasket")]
        [ProducesResponseType(typeof(BasketDto), 200)]
        public IActionResult GenerateBasket()
        {
            var result = _basketService.GenerateEmptyBasket();
            return Ok(result);
        }

        [HttpGet]
        [Route("GetBasketItems")]
        [ProducesResponseType(typeof(BasketItemDto), 200)]
        public async Task<IActionResult> GetBasketItems(Guid basketId)
        {
            var result = await _basketService.GetBasketItems(new GetBasketItemQuery(basketId));
            return Ok(result);
        }

        [HttpPost]
        [Route("AddItemToBasket")]
        [ProducesResponseType(typeof(BasketItemDto), 200)]
        public async Task<IActionResult> AddItemToBasket([FromBody] AddItemToBasketCommand command)
        {
            var result = await _basketService.AddItemToBasket(command);
            return Ok(result);
        }

        [HttpPut]
        [Route("UpdateItemQuantity")]
        [ProducesResponseType(typeof(BasketItemDto), 200)]
        public async Task<IActionResult> UpdateBasketItem(UpdateItemQuantityCommand command)
        {
            var result = await _basketService.UpdateItemQuantity(command);
            return Ok(result);
        }

        [HttpDelete]
        [Route("RemoveItemFromBasket")]
        [ProducesResponseType(typeof(BasketItemDto), 200)]
        public async Task<IActionResult> RemoveItemFromBasket(Guid itemId, Guid basketId)
        {
            var result = await _basketService.RemoveItemFromBasket(new RemoveItemFromBasketCommand(itemId, basketId));
            return Ok(result);
        }
    }
}