using AutoMapper;
using RestaurantAPI.Core.Application.Interfaces.Repository;
using RestaurantAPI.Core.Application.Interfaces.Services;
using RestaurantAPI.Core.Application.ViewModel.Order;
using RestaurantAPI.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAPI.Core.Application.Services
{
    public class OrderServices : GenericServices<SaveOrderViewModel,OrderViewModel,Order>,IOrderServices
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderServices(IOrderRepository orderRepository, IMapper mapper) : base(orderRepository,mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<List<OrderViewModel>> GetAllViewModelWithInclude() {

            var List = await _orderRepository.GetExtensiveIncludeAsync();

            return _mapper.Map<List<OrderViewModel>>(List);
        
        }

        public async Task<OrderViewModel> GetByIdWithInclude(int id)
        {

            var list = await _orderRepository.GetExtensiveIncludeAsync();

            return _mapper.Map<OrderViewModel>(list.FirstOrDefault(x => x.Id == id));

        }
    }
}
