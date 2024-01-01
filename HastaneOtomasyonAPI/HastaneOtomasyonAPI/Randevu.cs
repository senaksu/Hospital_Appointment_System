using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HastaneOtomasyonAPI.Models
{
    public class Randevu
    {
        [Key]
        public int Id { get; set; }

        [StringLength(11, ErrorMessage = "kullanici adinizi giriniz")]
        public string tc { get; set; }

        public DateTime randevuZamani { get; set; }

        [ForeignKey("Doktor")]

        public int doktorId { get; set; }
        public Doktor doktor { get; set; }
    }
}
