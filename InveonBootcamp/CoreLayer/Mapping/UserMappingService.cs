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
        public UserAppDto MapToUserAppDto(UserApp user)
        {

            return _mapper.Map<UserAppDto>(user);
        }
    }
}
