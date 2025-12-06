using Core.IdentityEntities;
using Microsoft.AspNetCore.Identity;
using Services.Services.TokenServices;
using Services.Services.UserServices.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.UserServices
{
    public class UserServices : IUserServices
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        public UserServices(UserManager<AppUser> userManager,ITokenService token,SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _tokenService = token;
            _signInManager = signInManager;
        }

        public async Task<UserDto> Login(LoginDto loginDto)
        {
            var user= await _userManager.FindByEmailAsync(loginDto.Email);

            if (user == null)
                return null;

            var result =await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (!result.Succeeded)
                return null;

            return new UserDto
            {
                DisplayName = user.DisplayName,
                Email = user.Email,
                Token = _tokenService.CreateToken(user)

            };
        }

        public async Task<UserDto> Register(RegisterDto registerDto)
        {
            var user= await _userManager.FindByEmailAsync(registerDto.Email);

            if (user != null)
                return null;

            var appuser = new AppUser()
            {
                DisplayName = registerDto.DisplayName,
                Email = registerDto.Email,
                UserName = registerDto.Email.Split("@")[0],
            };

            var result = await _userManager.CreateAsync(appuser,registerDto.Password);
            if (!result.Succeeded)
                return null;

            else {
                return new UserDto
                {
                    DisplayName = appuser.DisplayName,
                    Email = appuser.Email,
                    Token = _tokenService.CreateToken(appuser)
                };
            }

            

        }


        


    }
}
