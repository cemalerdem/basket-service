using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Entity.Base;
using Newtonsoft.Json;

namespace Data.Entity
{
    public class BasketView : AuditableEntity<Guid>
    {
        public void Handle()
        {
            Id = Guid.NewGuid();
        }
    }
}