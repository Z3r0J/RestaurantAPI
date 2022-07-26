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

        [HttpGet("List")]
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
