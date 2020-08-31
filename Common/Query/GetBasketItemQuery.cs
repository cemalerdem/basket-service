using System;

namespace Common.Query
{
    public class GetBasketItemQuery
    {
        public GetBasketItemQuery(Guid basketId)
        {
            BasketId = basketId;
        }
        public Guid BasketId { get; set; }
    }
}