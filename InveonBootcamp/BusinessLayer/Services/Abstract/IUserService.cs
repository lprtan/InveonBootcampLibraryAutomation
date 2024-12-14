using Azure;
using CoreLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Abstract
{
    public interface IUserService
    {
        Task<(bool IsSuccess, string? ErrorMessage, UserAppDto? User)> CreateUserAsync(UserDto createUserDto);

        Task<(bool IsSuccess, string? ErrorMessage, UserAppDto? User)> GetUserByNameAsync(string userName);
        Task<(bool IsSuccess, string? ErrorMessage, UserAppDto? User)> LoginUserAsync(UserDto loginUserDto);
    }

}
