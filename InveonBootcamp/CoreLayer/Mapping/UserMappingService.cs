using AutoMapper;
using CoreLayer.Dtos;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Mapping
{
    public class UserMappingService : IUserMappingService
    {
        private readonly IMapper _mapper;
        public UserMappingService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<UserDto> MapToUserAppDtoList(List<UserApp> users)
        {
            return _mapper.Map<List<UserDto>>(users);
        }

        public UserLoginDto MapToUserLoginDto(UserApp user)
        {
            return _mapper.Map<UserLoginDto>(user);
        }

        UserDto IUserMappingService.MapToUserAppDto(UserApp user)
        {
            return _mapper.Map<UserDto>(user);
        }
    }
}
