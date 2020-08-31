using System;
using System.Collections.Generic;

namespace Common.ViewModels
{
    public class BasketDto
    {

        public BasketDto(Guid id)
        {
            Id = id;
            BasketItems = new List<BasketItemDto>();
        }

        public Guid Id { get; set; }
        public List<BasketItemDto> BasketItems { get; set; }
    }
}