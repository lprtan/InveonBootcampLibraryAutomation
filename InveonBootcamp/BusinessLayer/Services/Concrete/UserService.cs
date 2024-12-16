using BusinessLayer.Services.Abstract;
using CoreLayer.Dtos;
using CoreLayer.Mapping;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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

        public async Task<(bool IsSuccess, string? ErrorMessage, UserDto? User)> CreateUserAsync(UserDto createUserDto)
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

        public async Task<(bool IsSuccess, string? ErrorMessage, List<UserDto>? User)> DeleteByIdAsync(string id)
        {
            var user = await _user.FindByIdAsync(id);

            if(user == null)
            {
                return (false, "Kullanıcı Bulunamadı", null);
            }

            var result = await _user.DeleteAsync(user);

            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(x => x.Description));
                return (false, errors, null);
            }

            return (true, null, null);
        }

        public async Task<(bool IsSuccess, string? ErrorMessage, List<UserDto>? User)> GetAllUserAsync()
        {
            var users = await _user.Users.ToListAsync();

            if (users == null)
            {
                var errorMessage = "Kullanıcı listesi boş";
                return (false, errorMessage, null);
            }

            var userDto = _userMappingService.MapToUserAppDtoList(users);
            return (true, null, userDto);
        }

        public async Task<(bool IsSuccess, string? ErrorMessage, UserDto? User)> GetUserByNameAsync(string userName)
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

        public async Task<(bool IsSuccess, string? ErrorMessage, UserDto? User)> LoginUserAsync(UserDto loginUserDto)
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

        public async Task<(bool IsSuccess, string? ErrorMessage, UserDto? User)> UpdateUserAsync(UserDto updateUserDto)
        {
            var user = await _user.FindByNameAsync(updateUserDto.UserName);

            if (user == null)
            {
                return (false, "Kullanıcı bulunamadı.", null);
            }

            user.Email = updateUserDto.Email;
            user.FirstName = updateUserDto.FirstName;
            user.LastName = updateUserDto.LastName;

            if (!string.IsNullOrEmpty(updateUserDto.Password))
            {
                var token = await _user.GeneratePasswordResetTokenAsync(user);
                var result = await _user.ResetPasswordAsync(user, token, updateUserDto.Password);

                if (!result.Succeeded)
                {
                    var errors = string.Join(", ", result.Errors.Select(x => x.Description));
                    return (false, errors, null);
                }
            }

            var updateResult = await _user.UpdateAsync(user);

            if (!updateResult.Succeeded)
            {
                var errors = string.Join(", ", updateResult.Errors.Select(x => x.Description));
                return (false, errors, null);
            }

            var userDto = _userMappingService.MapToUserAppDto(user);

            return (true, null, userDto);
        }
    }
}
