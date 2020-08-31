using System;

namespace Common.Command
{
    public class RemoveItemFromBasketCommand
    {
        public RemoveItemFromBasketCommand(Guid itemId, Guid basketId)
        {
            ItemId = itemId;
            BasketId = basketId;
        }
        public Guid BasketId { get; set; }
        public Guid ItemId { get; set; }
    }
}