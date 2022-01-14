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
    [Table("References")]
    public class References : MyEntityBase
    {
        [DisplayName("Adınız Soyadınız")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez."), StringLength(50, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string NameAndSurname { get; set; }

        [DisplayName("Şirket/Kurum")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez."), StringLength(50, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Company { get; set; }

        [DisplayName("Unvan")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez."), StringLength(50, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Degree { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez."), StringLength(50, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır."), EmailAddress(ErrorMessage = "{0} alanı için geçerli bir e-mail adresi giriniz.")]
        public string Email { get; set; }

        [DisplayName("Web Sitesi")]
        public string Website { get; set; }

        [DisplayName("Konu")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez."), StringLength(100, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Subject { get; set; }

        [DisplayName("Yorum")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public string Comment { get; set; }

        [DisplayName("Yorum Durumu"),DefaultValue(true)]
        public bool CommentStatus { get; set; }

        public int ProjectsId { get; set; }
        public virtual Projects Projects { get; set; }
    }
}
