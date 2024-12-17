﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Dtos
{
    public class UserLoginDto
    {
        [Display(Name = "Kullanıcı adı")]
        public string? UserName { get; set; }

        [Display(Name = "Şifre")]
        public string? Password { get; set; }
    }
}
