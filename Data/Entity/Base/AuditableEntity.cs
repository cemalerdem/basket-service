using System;

namespace Data.Entity.Base
{
    public class AuditableEntity<TId>
    {
        public AuditableEntity()
        {
            CreatedAtUtc = DateTime.UtcNow;
        }
        public TId Id { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public DateTime? UpdateAtUtc { get; set; }
    }
}