using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HastaneOtomasyonu.Models
{
    public class Randevu
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(11,ErrorMessage = "Lütfen 11 haneli Türkiye Cumhuriyeti Kimlik Numaranızı Giriniz")]
        [MinLength(11,ErrorMessage = "Lütfen 11 haneli Türkiye Cumhuriyeti Kimlik Numaranızı Giriniz")]
        public string tc { get; set; }



        [ForeignKey("Doktor")]
        public int doktorId { get; set; }

        public Doktor doktor { get; set;}

        public DateTime randevuzamani { get; set; }






    }
}
