using System.ComponentModel.DataAnnotations;

namespace HastaneOtomasyonu.Models
{
    public class Poliklinik
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage ="Boş bırakmayınız")]
        public string adi { get; set; }



    }
}
