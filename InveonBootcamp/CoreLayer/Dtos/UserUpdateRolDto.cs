﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Dtos
{
    public class UserUpdateRolDto
    {
        public string? UserId { get; set; }
        public string? OldRoleName { get; set; }
    }
}
