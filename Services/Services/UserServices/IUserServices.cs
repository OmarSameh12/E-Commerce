using Services.Services.UserServices.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.UserServices
{
    public interface IUserServices
    {

        public  Task<UserDto> Register(RegisterDto registerDto);
        public  Task<UserDto> Login(LoginDto loginDto);

    }
}
