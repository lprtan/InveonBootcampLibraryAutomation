using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Dtos
{
    public class UserWithRolesDto
    {
        public UserDto? User { get; set; }
        public List<string>? Roles { get; set; }
    }
}
