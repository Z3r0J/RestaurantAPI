using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Core.Application.Interfaces.Services;
using RestaurantAPI.Core.Application.ViewModel.Ingredient;
using System;
using System.Threading.Tasks;

namespace RestaurantAPI.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class IngredientController : BaseAPIController
    {
        private readonly IIngredientServices _ingredientServices;
        public IngredientController(IIngredientServices ingredientServices)
        {
            _ingredientServices = ingredientServices;
        }

        [HttpPost("Create")]
        [Authorize(Roles = "ADMINISTRATOR")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddIngredientAsync(SaveIngredientViewModel model) {
            try
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                await _ingredientServices.Add(model);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("Update/{id}")]
        [Authorize(Roles = "ADMINISTRATOR")]
        [ProducesResponseType(StatusCodes.Status200OK,Type = typeof(SaveIngredientViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateIngredientAsync(int id, SaveIngredientViewModel model) {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                model.Id = id;

                await _ingredientServices.Update(model, id);

                return Ok(model);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }
        
        [HttpGet("GetById/{id}")]
        [Authorize(Roles = "ADMINISTRATOR")]
        [ProducesResponseType(StatusCodes.Status200OK,Type = typeof(SaveIngredientViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIdAsync(int id) {

            try
            {

                var ingredient = await _ingredientServices.GetByIdSaveViewModel(id);

                if (ingredient == null)
                {
                    return NotFound();
                }


                return Ok(ingredient);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpGet("List")]
        [Authorize(Roles = "ADMINISTRATOR")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IngredientViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetIngredientAsync() {

            try
            {
                var Ingredients = await _ingredientServices.GetAllViewModel();

                if (Ingredients == null || Ingredients.Count==0)
                {
                    return NotFound();
                }

                return Ok(Ingredients);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        
        }

    }
}
