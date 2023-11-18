using Fluent_Api.Infrastructure.Dtos;
using Fluent_Api.Infrastructure.Services.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace Fluentp_Api_Example.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userservice;

        [HttpGet]
        public IActionResult GetAllAsync()
        {
            var result = _userservice.GetAllAsync();
            return Ok(result.Result);
        }
        [HttpPost]
        public IActionResult CreateAsync(UserDto user)
        {
            var result = _userservice.CreateAsync(user);
            return Ok(result.Result);
        }
        [HttpGet]
        public IActionResult GetById(int id)
        {
            var result = _userservice.GetByIdAsync(id);
            return Ok(result.Result);
        }
        [HttpPut]
        public IActionResult UpdateAsync(int id, UserDto user)
        {
            var result = _userservice.UpdateAsync(id, user);
            return Ok(result.Result);
        }
        [HttpDelete]
        public IActionResult DeleteById(int id)
        {
            var result = _userservice.DeleteAsync(id);
            return Ok(result.Result);
        }
    }
}
