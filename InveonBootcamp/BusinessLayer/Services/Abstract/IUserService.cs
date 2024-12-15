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
        Task<(bool IsSuccess, string? ErrorMessage, UserDto? User)> CreateUserAsync(UserDto createUserDto);

        Task<(bool IsSuccess, string? ErrorMessage, UserDto? User)> GetUserByNameAsync(string userName);
        Task<(bool IsSuccess, string? ErrorMessage, UserDto? User)> LoginUserAsync(UserDto loginUserDto);
        Task<(bool IsSuccess, string? ErrorMessage, UserDto? User)> UpdateUserAsync(UserDto updateUserDto);
    }

}
