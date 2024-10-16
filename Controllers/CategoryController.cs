using DigitalMenuApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DigitalMenuApi.Controllers
{
    public class CategoryController : BaseApiController
    {
        private readonly IRestService _service;
        public CategoryController(IRestService service)
        {
            _service = service;
        }
        
        // /api/category/All
        [HttpGet("All")]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _service.GetAllCategoriesAsync();
            if (categories == null)
            {
                return NoContent();
            }
            return Ok(categories);
        }
    }
}
