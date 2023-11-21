using Fluent_Api.Infrastructure.Dtos;
using Fluent_Api.Infrastructure.Services.BookCategoryServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fluentp_Api_Example.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookCategoryController : ControllerBase
    {
        private readonly IBookCategoryService _bookCategoryService;

        public BookCategoryController(IBookCategoryService bookCategoryService)
        {
            _bookCategoryService = bookCategoryService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _bookCategoryService.GetAllAsync();
            return Ok(result.Result);
        }

        [HttpPost]
        public IActionResult CreateBookCategory(BookCategoryDto bookCategoryDto)
        {
            var result = _bookCategoryService.CreateAsync(bookCategoryDto);
            return Ok(result.Result);
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var result = _bookCategoryService.GetByIdAsync(id);
            return Ok(result.Result);

        }

        [HttpPut]
        public IActionResult UpdateBookCategory(int id ,BookCategoryDto bookCategoryDto)
        {
            var result = _bookCategoryService.UpdateAsync(id, bookCategoryDto);
            return Ok(result.Result);
            
        }
        [HttpDelete]
        public IActionResult DeleteById(int id)
        {
            var result = _bookCategoryService.DeleteAsync(id);
            return Ok(result.Result);
        }

    }
}
