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

        UserDto IUserMappingService.MapToUserAppDto(UserApp user)
        {
            return _mapper.Map<UserDto>(user);
        }
    }
}
