using RestaurantAPI.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAPI.Core.Domain.Entities
{
    public class Order : AuditableBaseEntity
    {
        public double SubTotal { get; set; }
        public int OrderStatusId { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public int TableId { get; set; }
        public Table Table { get; set; }

        public ICollection<OrderDish> OrderDishes { get; set; }
    }
}
