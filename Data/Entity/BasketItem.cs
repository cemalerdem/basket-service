using System;
using Common.Command;
using Data.Entity.Base;

namespace Data.Entity
{
    public class BasketItem : AuditableEntity<Guid>
    {
        public Guid ItemId { get; set; }
        public int Quantity { get; set; }
        public Guid BasketId { get; set; }


        public void Handle(UpdateItemQuantityCommand command)
        {
            UpdateAtUtc = DateTime.UtcNow;
            Quantity = command.Quantity;
        }
    }
}