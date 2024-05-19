using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StockExchange.DTOs;
using Stocks.Core.Entites.identity;

namespace StockExchange.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto model)
        { 
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null) return Unauthorized(StatusCode(401));

            var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);

            if (!result.Succeeded) return Unauthorized(StatusCode(401));



            return Ok(new UserDto()
            {
                DisplayName = model.DisplayName,
                Email = model.Email,
                Token = ""

            });
        }


    }
}
