using Core.IdentityDbContext;
using Core.IdentityEntities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Services.Services.TokenServices;
using System.Text;

namespace E_Commerce.Extentions
{
    public static class AppIdentityServicesExtentions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services,IConfiguration _configuration) {
            var builder = services.AddIdentityCore<AppUser>();
            builder= new Microsoft.AspNetCore.Identity.IdentityBuilder(builder.UserType,services);
            builder.AddEntityFrameworkStores<AppIdentityDbContext>();
          
            builder.AddSignInManager<SignInManager<AppUser>>();
         
            
            
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:Key"])),
                        ValidateIssuer = true,
                        ValidIssuer = _configuration["Token:Issuer"],
                        ValidateAudience = false
                    };
                
                });  
            return services;
            
        }


    }
}
