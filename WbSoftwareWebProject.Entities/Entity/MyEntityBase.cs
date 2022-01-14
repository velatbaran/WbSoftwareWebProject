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
    public class MyEntityBase
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("Kayıt Tarihi")]
        public DateTime? CreatedOn { get; set; }

        [DisplayName("Güncelleme Tarihi")]
        public DateTime? UpdatedOn { get; set; }

        [DisplayName("Kaydeden")]
        public string SavedUsername { get; set; }
    }
}
