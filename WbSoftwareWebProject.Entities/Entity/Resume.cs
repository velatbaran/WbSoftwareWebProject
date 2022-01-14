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
    [Table("Resume")]
    public class Resume : MyEntityBase
    {
        [DisplayName("Kurum/Şirket")]
        [Required(ErrorMessage ="{0} alanı boş geçilemez."),StringLength(100,ErrorMessage ="{0} alanı max. {1} karakter olmalıdır.")]
        public string Corporation { get; set; }

        [DisplayName("Görev")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez."), StringLength(100, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Task { get; set; }

        [DisplayName("Başlama Tarihi")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        [Column(TypeName = "datetime2")]
        public DateTime StartDate { get; set; }

        [DisplayName("Bitiş Tarihi")]
        [Column(TypeName = "datetime2")]
        public DateTime? EndDate { get; set; }

        [DisplayName("Hala Çalışılıyor Mu?")]
        public bool IsActive { get; set; }

        [DisplayName("Açıklama")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public string Description { get; set; }

        [DisplayName("Adres")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public string Address { get; set; }

    }
}
