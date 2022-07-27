using RestaurantAPI.Core.Application.ViewModel.TableStatus;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAPI.Core.Application.ViewModel.Table
{
    public class SaveTableViewModel
    {
        public int Id { get; set; }
        [Range(1,int.MaxValue,ErrorMessage ="Min 1 people to create this table")]
        public int MaximumPeople { get; set; }
        [Required(ErrorMessage ="Description is required")]
        public string Description { get; set; }
        public int TableStatusId { get; set; }
    }
}
