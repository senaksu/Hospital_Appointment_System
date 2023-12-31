using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HastaneOtomasyonu.Models
{
    public class Randevu
    {
        [Key]
        public int Id { get; set; }

        [StringLength(11,ErrorMessage ="TC Numaranızı giriniz")]
        public string tc { get; set; }

        public DateTime randevuZamani { get; set; }

        [ForeignKey("Doktor")]

        public int doktorId { get; set; }
        public Doktor doktor { get; set; }  

    }
}
