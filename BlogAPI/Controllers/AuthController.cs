using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("login")]
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            var login = _authService.Login(userForLoginDto);
            if (!login.Success)
            {
                return BadRequest(login.Message);
            }

            var result = _authService.CreateAccessToken(login.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);

        }

        [HttpPost("register")]
        public IActionResult Register(UserForRegisterDto userForRegister)
        {
            var userToCheck = _authService.UserToCheck(userForRegister.Email);
            if (!userToCheck.Success)
            {
                return BadRequest(userToCheck.Message);
            }
            var register = _authService.Register(userForRegister);
            var result = _authService.CreateAccessToken(register.Data);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Data);
        }
    }
}
