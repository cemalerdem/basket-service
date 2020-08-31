using System;
using Common.Command;
using Data.Entity.Base;

namespace Data.Entity
{
    public class ItemDetailView : AuditableEntity<Guid>
    {
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public bool IsActive { get; set; }


        public void Handle(int updatedStockQauntity)
        {
            Quantity = updatedStockQauntity;
        }
    }
}