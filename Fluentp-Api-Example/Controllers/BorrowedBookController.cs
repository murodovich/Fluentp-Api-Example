using Fluent_Api.Infrastructure.Dtos;
using Fluent_Api.Infrastructure.Services.BorrowedBookServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fluentp_Api_Example.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BorrowedBookController : ControllerBase
    {
        private readonly IBorrowedBookService _borrowservice;

        public BorrowedBookController(IBorrowedBookService borrowservice)
        {
            _borrowservice = borrowservice;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _borrowservice.GetAllAsync();
            return Ok(result.Result);

        }
        [HttpPost]
        public IActionResult Create(BorrowedBookDto borrowedBookDto)
        {
            var result = _borrowservice.CreateAsync(borrowedBookDto);
            return Ok(result.Result);
        }
        [HttpGet]
        public IActionResult GetById(int id)
        {
            var result = _borrowservice.GetByIdAsync(id);
            return Ok(result.Result);
        }
        [HttpPut]
        public IActionResult Update(int id,BorrowedBookDto borrowedBook)
        {
            var result = _borrowservice.UpdateAsync(id,borrowedBook);
            return Ok(result.Result);
        }
        [HttpDelete]
        public IActionResult DeleteById(int id)
        {
            var result = _borrowservice.DeleteAsync(id);
            return Ok(result.Result);
        }


    }
}
