using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Dtos
{
    public class UserDto
    {
        public string Id { get; set; }

        [Display(Name = "Kullanıcı adı")]
        public string UserName { get; set; }

        [Display(Name = "E-Posta")]
        public string Email { get; set; }

        [Display(Name = "Şifre")]
        public string Password { get; set; }

        [Display(Name = "Ad")]
        public string FirstName { get; set; }

        [Display(Name = "Soyad")]
        public string LastName { get; set; }
    }
}
