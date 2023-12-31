using System.ComponentModel.DataAnnotations;

namespace HastaneOtomasyonu.Models
{
    public class Poliklinik
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage ="Boş bırakmayınız")]
        [Display(Name ="Poliklinik Adı")]
        public string adi { get; set; }



    }
}
