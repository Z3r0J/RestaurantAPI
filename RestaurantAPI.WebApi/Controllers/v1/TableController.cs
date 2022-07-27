using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Core.Application.Interfaces.Services;
using RestaurantAPI.Core.Application.ViewModel.Order;
using RestaurantAPI.Core.Application.ViewModel.Table;
using System;
using System.Threading.Tasks;

namespace RestaurantAPI.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class TableController : BaseAPIController
    {
        private readonly ITableServices _tableServices;
        public TableController(ITableServices tableServices)
        {
            _tableServices = tableServices;
        }

        [HttpPost("Create")]
        [Authorize(Roles = "ADMINISTRATOR")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddTableAsync(SaveTableViewModel model) {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                await _tableServices.Add(model);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
                    
        }

        [HttpPut("Update/{id}")]
        [Authorize(Roles = "ADMINISTRATOR")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UpdateTableViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id,UpdateTableViewModel model) {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                model.Id = id;

                var info = await _tableServices.GetByIdSaveViewModel(id);
                info.Description = model.Description;
                info.MaximumPeople = model.MaximumPeople;

                await _tableServices.Update(info, id);

                return Ok(model);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
                    
        }

        [HttpGet("List")]
        [Authorize(Roles = "WAITER, ADMINISTRATOR")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TableViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllTableAsync() {

            try
            {
                var tableList = await _tableServices.GetAllWithInclude();

                if (tableList == null||tableList.Count==0)
                {
                    return NotFound();
                }

                return Ok(tableList);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        
        }

        [HttpGet("GetById/{id}")]
        [Authorize(Roles = "WAITER, ADMINISTRATOR")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TableViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIdAsync(int id) {

            try
            {
                var table = await _tableServices.GetByIdWithInclude(id);

                if (table == null)
                {
                    return NotFound();
                }

                return Ok(table);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        
        }

        [HttpGet("GetTableOrders/{id}")]
        [Authorize(Roles = "WAITER")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrderViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetOrdenById(int id) {

            try
            {
                var orders = await _tableServices.GetOrderByTable(id);

                if (orders == null || orders.Count == 0)
                {
                    return NotFound();
                }

                return Ok(orders);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        
        }

        [HttpPatch("ChangeStatus/{id}")]
        [Authorize(Roles = "WAITER")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ChangeStatusAsync(int id, ChangeStatusViewModel model) {

            try
            {

                var tableViewModel = await _tableServices.GetByIdSaveViewModel(id);

                if (tableViewModel==null)
                {
                    return NotFound();
                }

                tableViewModel.TableStatusId = model.StatusId;

                await _tableServices.Update(tableViewModel, tableViewModel.Id);

                return NoContent();

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        
        }

    }
}
