using System;
using System.Collections.Generic;

namespace Common.ViewModels
{
    public class BasketItemDto
    {
        public BasketItemDto()
        {
            
        }
        public BasketItemDto(Guid basketId)
        {
            BasketId = basketId;
            Products = new List<ProductDto>();
        }

        public BasketItemDto(Guid basketId, List<ProductDto> products)
        {
            BasketId = basketId;
            Products = products;
        }

        public Guid BasketId { get; set; }
        public List<ProductDto> Products { get; set; }
    }
}