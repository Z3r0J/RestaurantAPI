using RestaurantAPI.Core.Application.ViewModel.OrderStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace RestaurantAPI.Core.Application.ViewModel.Order
{
    public class SaveOrderViewModel
    {
        public int Id { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public int OrderStatusId { get; set; }
        public int TableId { get; set; }
        public List<int> DishIds { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public double SubTotal { get; set; }
    }
}
