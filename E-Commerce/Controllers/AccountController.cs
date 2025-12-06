using Core.IdentityEntities;
using E_Commerce.HandleResponses;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Services.TokenServices;
using Services.Services.UserServices;
using Services.Services.UserServices.Dto;

namespace E_Commerce.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IUserServices _userServices;

        public AccountController(IUserServices userServices)
        {
            _userServices = userServices;
        }
        [HttpPost("Register")]

        public async  Task<ActionResult<UserDto>> Register(RegisterDto registerDto) {
                var user=await _userServices.Register(registerDto);
            if (user is null)
                return BadRequest(new ApiResponse(400,"Email Already Exits"));
            return Ok(user); 

             
        } 
        [HttpPost("Login")]

        public async  Task<ActionResult<UserDto>> Login(LoginDto loginDto) {
                var user=await _userServices.Login(loginDto);
         
            if (user is null)
                return BadRequest(new ApiResponse(401));
            return Ok(user); 

             
        }


    }
}
