using BusinessLayer.Services.Abstract;
using CoreLayer.Dtos;
using CoreLayer.Mapping;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly UserManager<UserApp> _user;
        private readonly IUserMappingService _userMappingService;

        public UserService(UserManager<UserApp> user, IUserMappingService userMappingService)
        {
            _user = user;
            _userMappingService = userMappingService;
        }

        public async Task<(bool IsSuccess, string? ErrorMessage, UserAppDto? User)> CreateUserAsync(UserDto createUserDto)
        {
            var user = new UserApp
            {
                Email = createUserDto.Email,
                UserName = createUserDto.UserName,
                FirstName = createUserDto.FirstName,
                LastName = createUserDto.LastName
            };

            var result = await _user.CreateAsync(user, createUserDto.Password);

            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(x => x.Description));
                return (false, errors, null);
            }

            var userDto = _userMappingService.MapToUserAppDto(user);

            return (true, null, userDto);
        }

        public async Task<(bool IsSuccess, string? ErrorMessage, UserAppDto? User)> GetUserByNameAsync(string userName)
        {
            var user = await _user.FindByNameAsync(userName);

            if(user == null)
            {
                var errorMessage = "Kullanıcı bulunmadı";
                return (false, errorMessage, null);
            }

            var userDto = _userMappingService.MapToUserAppDto(user);

            return (true, null, userDto);
        }

        public async Task<(bool IsSuccess, string? ErrorMessage, UserAppDto? User)> LoginUserAsync(UserDto loginUserDto)
        {
            var user = await _user.FindByNameAsync(loginUserDto.UserName);

            if(user == null)
            {
                return (false, "Kullanıcı adı yanlış.", null);
            }

            var isPasswordValid = await _user.CheckPasswordAsync(user, loginUserDto.Password);

            if (!isPasswordValid)
            {
                return (false, "Şifre yanlış.", null);
            }

            var userDto = _userMappingService.MapToUserAppDto(user);

            return (true, null, userDto);
        }
    }
}
