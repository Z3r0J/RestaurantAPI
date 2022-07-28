using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Core.Application.Interfaces.Services;
using RestaurantAPI.Core.Application.ViewModel.DishOrder;
using RestaurantAPI.Core.Application.ViewModel.Order;
using System;
using System.Threading.Tasks;

namespace RestaurantAPI.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class OrderController : BaseAPIController
    {
        private readonly IOrderServices _orderServices;
        private readonly IDishOrderServices _dishOrderServices;
        private readonly IDishServices _dishServices;
        public OrderController(IOrderServices orderServices, IDishOrderServices dishOrderServices,IDishServices dishServices)
        {
            _orderServices = orderServices;
            _dishOrderServices = dishOrderServices;
            _dishServices = dishServices;
        }
        [HttpGet("List")]
        [Authorize(Roles = "WAITER")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrderViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllOrderAsync() {

            try
            {
                var orderList = await _orderServices.GetAllViewModelWithInclude();

                if (orderList==null||orderList.Count==0)
                {
                    return NotFound();
                }

                return Ok(orderList);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }


        }

        [HttpPost("Create")]
        [Authorize(Roles = "WAITER")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> AddOrderAsync(SaveOrderViewModel model) {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                model.OrderStatusId = 1;

                var order = await _orderServices.Add(model);

                foreach (int DishId in model.DishIds)
                {
                    var Dish = new SaveDishOrderViewModel {DishId = DishId,OrderId=order.Id};
                    var newd = await _dishOrderServices.Add(Dish);

                    var info = await _dishServices.GetByIdSaveViewModel(newd.DishId);

                    order.SubTotal += info.Price;
                }

                await _orderServices.Update(order, order.Id);

                return NoContent();
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

    }
}
