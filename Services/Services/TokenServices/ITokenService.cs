using Core.IdentityEntities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.TokenServices
{
    public interface ITokenService
    {
        public string CreateToken(AppUser appUser);
    }
}
