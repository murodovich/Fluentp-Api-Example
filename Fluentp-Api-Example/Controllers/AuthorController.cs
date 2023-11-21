using Fluent_Api.Infrastructure.Dtos;
using Fluent_Api.Infrastructure.Services.AuthorServices;
using Microsoft.AspNetCore.Mvc;

namespace Fluentp_Api_Example.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorservice;

        public AuthorController(IAuthorService authorservice)
        {
            _authorservice = authorservice;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _authorservice.GetAllAsync();
            return Ok(result.Result);
        }
        [HttpPost]
        public IActionResult CreateAsyncs(AuthorDto author)
        {
            var result = _authorservice.CreateAsync(author);
            return Ok(result.Result);
        }
        [HttpDelete]
        public IActionResult DeleteAsync(int id)
        {
            var result = _authorservice.DeleteAsync(id);
            return Ok(result.Result);
        }
        [HttpGet]
        public IActionResult GetById(int id)
        {
            var result = _authorservice.GetByIdAsync(id);
            return Ok(result.Result);
        }
        [HttpPut]
        public IActionResult UpdateAuthor(int Id, AuthorDto author)
        {
            var result = _authorservice.UpdateAsync(Id, author);
            return Ok(result.Result);
        }

    }
}
