using Fluent_Api.Infrastructure.Services.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace Fluentp_Api_Example.Controllers
{
    [Route("api/[controller]/action")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userservice;

        [HttpGet]
        public  IActionResult GetAllAsync()
        {
            var result =  _userservice.GetAllAsync();
            return Ok(result);
        }
    }
}
