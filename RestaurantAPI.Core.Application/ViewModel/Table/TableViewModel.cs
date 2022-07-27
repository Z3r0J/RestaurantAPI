using RestaurantAPI.Core.Application.ViewModel.TableStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAPI.Core.Application.ViewModel.Table
{
    public class TableViewModel
    {
        public int Id { get; set; }
        public int MaximumPeople { get; set; }
        public string Description { get; set; }
        public int TableStatusId { get; set; }
        public TableStatusViewModel TableStatus { get; set; }
    }
}
