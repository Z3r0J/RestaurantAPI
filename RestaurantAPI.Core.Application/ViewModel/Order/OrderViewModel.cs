using RestaurantAPI.Core.Application.ViewModel.Dish;
using RestaurantAPI.Core.Application.ViewModel.OrderStatus;
using RestaurantAPI.Core.Application.ViewModel.TableStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAPI.Core.Application.ViewModel.Order
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public int OrderStatusId { get; set; }
        public OrderStatusViewModel OrderStatus { get; set; }
        public int TableId { get; set; }
        public List<DishViewModel> Dishes { get; set; }
        public double SubTotal { get; set; }
    }
}
