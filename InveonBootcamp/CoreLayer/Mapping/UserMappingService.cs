using AutoMapper;
using CoreLayer.Dtos;
using EntityLayer.Concrete;
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

        UserDto IUserMappingService.MapToUserAppDto(UserApp user)
        {
            return _mapper.Map<UserDto>(user);
        }
    }
}
