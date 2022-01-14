using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WbSoftwareWebProject.Entities.ValueObjectModel
{
    public class ResetPasswordViewmModel
    {
        [DisplayName("Şifre"), Required(ErrorMessage = "{0} alanı boş geçilemez."),
    StringLength(50, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır."), DataType(DataType.Password)]
        public string Password { get; set; }
        [DisplayName("Şifre Tekrar"), Required(ErrorMessage = "{0} alanı boş geçilemez."), StringLength(50, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır."),
            DataType(DataType.Password), Compare("Password", ErrorMessage = "{0} ile {1} uyuşmuyor.")]
        public string RePassword { get; set; }
    }
}
