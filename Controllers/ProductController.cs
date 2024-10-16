using Microsoft.AspNetCore.Mvc;
using DigitalMenuApi.Services;

namespace DigitalMenuApi.Controllers
{
    public class ProductController : BaseApiController
    {
        private readonly IRestService _service;
        public ProductController(IRestService service)
        {
            _service = service;
        }

        [HttpGet("All")]
        // /api/product/All/
        public async Task<IActionResult> GetAllProductsAsync()
        {
            var products = await _service.GetAllProductsAsync();
            
            if (products == null) return NoContent();
            
            return Ok(products);
        }


        // /api/product/{id}/
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleAsync(int id)
        {
            var product = await _service.GetSingleProductAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // /api/product/GetChefRecommendation/
        [HttpGet("GetChefRecommendations")]
        public async Task<IActionResult> GetChefRecommendationsAsync()
        {
            var chefRecommendations = await _service.GetChefRecommendationsAsync();

            if (chefRecommendations == null)
            {
                return NoContent();
            }
            return Ok(chefRecommendations);
        }

        // /api/product/GetChefRecommendation/
        [HttpGet("GetProductByCategory/{categoryName}")]
        public async Task<IActionResult> GetProductByCategoryAsync(string categoryName)
        {
            var products = await _service.GetProductsByCategoryName(categoryName);

            if (products == null)
            {
                return NoContent();
            }
            return Ok(products);
        }
    
        // /api/product/WhatIsTheDishOfToday/
        [HttpGet("WhatIsTheDishOfToday")]
        public async Task<IActionResult> GetDishOfTheDayAsync()
        {
            var dish = await _service.WhatIsTheDishOfToday();
            
            if (dish == null) return NotFound();
            
            return Ok(dish);
        }

        // /api/product/GetDishesOfTheWeek/
        [HttpGet("GetDishesOfTheWeek")]
        public async Task<IActionResult> GetDishesOfTheWeekAsync()
        {
            var dishes = await _service.GetDishesOfTheWeek();
            
            if (dishes == null) return NoContent();

            return Ok(dishes);
        }
    
    }
}
