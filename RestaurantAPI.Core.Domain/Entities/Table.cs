using RestaurantAPI.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAPI.Core.Domain.Entities
{
    public class Table : AuditableBaseEntity
    {
        public int MaximumPeople { get; set; }
        public string Description { get; set; }

        public int TableStatusId { get; set; }
        public TableStatus TableStatus { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
