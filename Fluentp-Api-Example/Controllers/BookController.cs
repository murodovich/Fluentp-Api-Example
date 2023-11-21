using Fluent_Api.Infrastructure.Dtos;
using Fluent_Api.Infrastructure.Services.BookServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fluentp_Api_Example.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet]
        public IActionResult BookGetAllAsync()
        {
            var result = _bookService.GetAllAsync();
            return Ok(result.Result);
        }

        [HttpPost]
        public IActionResult CreateBook(BookDto book)
        {
            var result = _bookService.CreateAsync(book);
            return Ok(result.Result);
        }
        [HttpGet]
        public IActionResult BookGetById(int id)
        {
            var result = _bookService.GetByIdAsync(id);
            return Ok(result.Result);
        }
        [HttpPut]
        public IActionResult BookUpdate(int id,BookDto book)
        {
            var result = _bookService.UpdateAsync(id, book);
            return Ok(result.Result);
        }
        [HttpDelete]
        public IActionResult DeleteBook(int id)
        {
            var result = _bookService.DeleteAsync(id);
            return Ok(result.Result);
        }



    }
}
