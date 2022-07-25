using RestaurantAPI.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAPI.Core.Domain.Entities
{
    public class OrderDish : AuditableBaseEntity
    {

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int DishId { get; set; }
        public Dish Dish { get; set; }

    }
}
