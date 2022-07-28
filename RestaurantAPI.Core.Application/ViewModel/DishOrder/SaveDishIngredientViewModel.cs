using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAPI.Core.Application.ViewModel.DishOrder
{
    public class SaveDishOrderViewModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int DishId { get; set; }
    }
}
