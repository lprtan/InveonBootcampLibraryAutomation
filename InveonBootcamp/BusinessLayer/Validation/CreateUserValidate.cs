using CoreLayer.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validation
{
    public class CreateUserValidate : AbstractValidator<UserDto>
    {
        public CreateUserValidate()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email boş geçilemez").EmailAddress().WithMessage("Yanlıkş email");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre boş geçilemez");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Ad boş geçilemez");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Soyad boş geçilemez");
        }
    }
}
