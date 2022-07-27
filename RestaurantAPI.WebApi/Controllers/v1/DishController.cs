using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Core.Application.Interfaces.Services;
using RestaurantAPI.Core.Application.ViewModel.Dish;
using RestaurantAPI.Core.Application.ViewModel.DishIngredient;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class DishController : BaseAPIController
    {
        private readonly IDishServices _dishServices;
        private readonly IDishIngredientServices _dishIngredientServices;
        private readonly IMapper _mapper;

        public DishController(IDishServices dishServices,IDishIngredientServices dishIngredientServices,IMapper mapper)
        {
            _dishServices = dishServices;
            _dishIngredientServices = dishIngredientServices;
            _mapper = mapper;
        }

        [HttpPost("Create")]
        [Authorize(Roles = "ADMINISTRATOR")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddIngredientAsync(SaveDishViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var result = await _dishServices.Add(model);

                if (model.IngredientIds != null || model.IngredientIds.Count>0)
                {
                    foreach (int ingredientid in model.IngredientIds)
                    {
                        SaveDishIngredientViewModel dishIngredient = new() { DishId = result.Id, IngredientId = ingredientid };

                        await _dishIngredientServices.Add(dishIngredient);
                    }
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("Update/{id}")]
        [Authorize(Roles = "ADMINISTRATOR")]
        [ProducesResponseType(StatusCodes.Status200OK,Type =typeof(SaveDishViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateDishAsync(int id,SaveDishViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                model.Id = id;

                await _dishServices.Update(model,id);

                if (model.IngredientIds != null || model.IngredientIds.Count>0)
                {
                   var ingredient = await _dishIngredientServices.GetAllViewModel();

                   var ingredientfilter = ingredient.Where(x => x.DishId == id);

                    foreach (DishIngredientViewModel ingredientvm in ingredientfilter)
                    {
                        await _dishIngredientServices.Delete(ingredientvm.Id);
                    }


                    foreach (int ingredientid in model.IngredientIds)
                    {
                        SaveDishIngredientViewModel dishIngredient = new() { DishId = id, IngredientId = ingredientid };

                        await _dishIngredientServices.Add(dishIngredient);
                    }
                }

                return Ok(model);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("List")]
        [Authorize(Roles = "ADMINISTRATOR")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DishViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetDishAsync() {

            try
            {
                var Dishes = await _dishServices.GetAllViewModelWithInclude();

                if (Dishes == null || Dishes.Count==0)
                {
                    return NotFound();
                }

                return Ok(Dishes);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        
        }
        
        [HttpGet("GetById/{id}")]
        [Authorize(Roles = "ADMINISTRATOR")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DishViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIdAsync(int id) {

            try
            {
                var dish = await _dishServices.GetByIdWithInclude(id);

                if (dish == null)
                {
                    return NotFound();
                }

                return Ok(dish);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        
        }

    }
}
