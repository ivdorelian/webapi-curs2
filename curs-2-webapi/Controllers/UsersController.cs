using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using curs_2_webapi.Models;
using curs_2_webapi.Services;
using curs_2_webapi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace curs_2_webapi.Controllers
{
    // https://jasonwatmore.com/post/2018/08/14/aspnet-core-21-jwt-authentication-tutorial-with-example-api
    [Authorize]
    //[Route("api/[controller]/[action]")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUsersService _userService;

        public UsersController(IUsersService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]LoginPostModel login)
        {
            var user = _userService.Authenticate(login.Username, login.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        //[HttpPost]
        public IActionResult Register([FromBody]RegisterPostModel registerModel)
        {
            var user = _userService.Register(registerModel);
            return Ok(user);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }
    }
}