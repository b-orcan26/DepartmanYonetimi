using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities
{
    public class Personel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [DisplayName("Ad")]
        public string ad { get; set; }

        [DisplayName("Soyad")]
        public string soyad { get; set; }

        public int DepartmanID { get; set; }
        
        public virtual Departman Departman { get; set; }
    }
}
