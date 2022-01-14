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
    [Table("Projects")]
    public class Projects : MyEntityBase
    {
        [DisplayName("Müşteri")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez."), StringLength(200, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Customer { get; set; }

        [DisplayName("Proje Adı")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez."), StringLength(200, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string ProjectName { get; set; }

        [DisplayName("Hizmet Alanı")]
        public int ServicesId { get; set; }

        [DisplayName("Proje Tarihi")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        [Column(TypeName = "datetime2")]
        public DateTime ProjectDate { get; set; }

        [DisplayName("Kullanılan Teknolojiler")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public string UsedTeknologies { get; set; }

        [DisplayName("Açıklama")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public string Description { get; set; }

        [DisplayName("Resim-1")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez."), StringLength(100, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Image1 { get; set; }

        [DisplayName("Resim-2")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez."), StringLength(50, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Image2 { get; set; }

        [DisplayName("Resim-3")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez."), StringLength(50, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Image3 { get; set; }

        public virtual Services Services { get; set; }

        public virtual List<References> Comments { get; set; }
        public Projects()
        {
            Comments = new List<References>();
        }
    }
}
