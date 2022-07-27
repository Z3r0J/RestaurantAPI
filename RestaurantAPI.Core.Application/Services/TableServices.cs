using AutoMapper;
using RestaurantAPI.Core.Application.Interfaces.Repository;
using RestaurantAPI.Core.Application.Interfaces.Services;
using RestaurantAPI.Core.Application.ViewModel.Order;
using RestaurantAPI.Core.Application.ViewModel.Table;
using RestaurantAPI.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAPI.Core.Application.Services
{
    public class TableServices : GenericServices<SaveTableViewModel,TableViewModel,Table>,ITableServices
    {
        private readonly ITableRepository _tableRepository;
        private readonly IMapper _mapper;

        public TableServices(ITableRepository tableRepository, IMapper mapper) : base(tableRepository,mapper)
        {
            _tableRepository = tableRepository;
            _mapper = mapper;
        }

        public async Task<List<TableViewModel>> GetAllWithInclude() { 
        
            var list = await _tableRepository.GetAllExtensiveInclude();

            return _mapper.Map<List<TableViewModel>>(list);
        
        }
        
        public async Task<TableViewModel> GetByIdWithInclude(int id) { 
        
            var list = await _tableRepository.GetAllExtensiveInclude();

            return _mapper.Map<TableViewModel>(list.FirstOrDefault(x=>x.Id == id));
        
        }

        public async Task<List<OrderViewModel>> GetOrderByTable(int id) {

            var list = await _tableRepository.GetAllExtensiveInclude();

            var table = list.FirstOrDefault(x => x.Id == id); 

            return _mapper.Map<List<OrderViewModel>>(table.Orders.Where(ord=>ord.OrderStatusId==1).ToList());    

        }
    }
}
