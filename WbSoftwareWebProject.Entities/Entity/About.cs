using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WbSoftwareWebProject.Entities.Entity
{
    [Table("About")]
    public class About : MyEntityBase
    {
        [DisplayName("Hakkımda(Kısa)"), Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public string ShortText { get; set; }

        [DisplayName("Hakkımda(Uzun)"), Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public string LongText { get; set; }

        [DisplayName("Profil Resmi"), Required(ErrorMessage = "{0} alanı boş geçilemez."), StringLength(100, ErrorMessage ="{0} alanı max. {1} karakter olmalıdır.")]
        public string ProfileImage { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez."), StringLength(50, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır."), EmailAddress(ErrorMessage = "{0} alanı için geçerli bir e-mail adresi giriniz.")]
        public string Email { get; set; }

        [DisplayName("Kullanıcı Adı")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez."), StringLength(50, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Username { get; set; }

        [DisplayName("Şifre")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez."), StringLength(50, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır."), DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
