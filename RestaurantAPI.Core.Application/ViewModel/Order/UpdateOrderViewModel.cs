using RestaurantAPI.Core.Application.ViewModel.OrderStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace RestaurantAPI.Core.Application.ViewModel.Order
{
    public class UpdateOrderViewModel
    {
        public int Id { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public List<int> DishIds { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public double SubTotal { get; set; }
    }
}
