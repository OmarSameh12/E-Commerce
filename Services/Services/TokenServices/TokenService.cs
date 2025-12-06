using Core.IdentityEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.TokenServices
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<AppUser> _userManager;
        public TokenService(IConfiguration configuration, UserManager<AppUser> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }

        public  string CreateToken(AppUser appUser)
        {
            //private claims
            var authClaims = new List<Claim> {
                new Claim(ClaimTypes.Email,appUser.Email),
                new Claim(ClaimTypes.GivenName,appUser.DisplayName)
            };
            var _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:Key"]));

            //To create token object
            var token = new JwtSecurityToken(
                    issuer: _configuration["Token:Issuer"],
                    expires:DateTime.Now.AddDays(30),
                    claims:authClaims,
                    //To add the signature 
                    signingCredentials:new SigningCredentials(_key,SecurityAlgorithms.HmacSha256Signature)
                    ) ;
            //To return the token the string itself
            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        
    }
}
