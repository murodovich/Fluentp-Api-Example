using Fluent_Api.Infrastructure.Dtos;
using Fluent_Api.Infrastructure.Services.CategpryServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fluentp_Api_Example.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult GetAllCategory()
        {
            var result = _categoryService.GetAllAsync();
            return Ok(result.Result);

        }

        [HttpPost]
        public IActionResult CreateCategory(CategoryDto category)
        {
            var result = _categoryService.CreateAsync(category);
            return Ok(result.Result);
        }

        [HttpGet]
        public IActionResult GetByIdCategory(int id)
        {
            var result = _categoryService.GetByIdAsync(id);
            return Ok(result.Result);
        }

        [HttpPut]
        public IActionResult UpdateCategory(int id, CategoryDto category)
        {
            var result = _categoryService.UpdateAsync(id, category);
            return Ok(result.Result);
        }
        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            var result = _categoryService.DeleteAsync(id);
            return Ok(result.Result);
        }

       
    }
}
