﻿using CoreLayer.Dtos;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Mapping
{
    public interface IUserMappingService
    {
        UserDto MapToUserAppDto(UserApp user);
        UserLoginDto MapToUserLoginDto(UserApp user);
        List<UserDto> MapToUserAppDtoList(List<UserApp> users);
    }
}
