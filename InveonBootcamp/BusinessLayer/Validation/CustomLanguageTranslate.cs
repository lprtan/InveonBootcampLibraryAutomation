using FluentValidation.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validation
{
    public class CustomLanguageTranslate : LanguageManager
    {
        public CustomLanguageTranslate()
        {
            AddTranslation("tr", "NotNullValidator", "{FirstName} alanı boş geçilemez.");
            AddTranslation("tr", "NotEmptyValidator", "{LastName} alanı boş geçilemez.");
            AddTranslation("tr", "NotEmptyValidator", "{UserNaame} alanı boş geçilemez.");
            AddTranslation("tr", "EmailValidator", "{Email} geçerli bir email adresi olmalıdır.");
            AddTranslation("tr", "MinimumLengthValidator", "{Password} en az {6} karakter olmalıdır.");
        }
    }
}
