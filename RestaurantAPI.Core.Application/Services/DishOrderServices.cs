using AutoMapper;
using RestaurantAPI.Core.Application.Interfaces.Repository;
using RestaurantAPI.Core.Application.Interfaces.Services;
using RestaurantAPI.Core.Application.ViewModel.DishOrder;
using RestaurantAPI.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAPI.Core.Application.Services
{
    public class DishOrderServices : GenericServices<SaveDishOrderViewModel,DishOrderViewModel,OrderDish>,IDishOrderServices
    {
        private readonly IDishOrderRepository _dishOrderRepository;
        private readonly IMapper _mapper;
        public DishOrderServices(IDishOrderRepository dishOrderRepository, IMapper mapper):base(dishOrderRepository, mapper)
        {
            _dishOrderRepository = dishOrderRepository;
            _mapper = mapper;
        }
    }
}
