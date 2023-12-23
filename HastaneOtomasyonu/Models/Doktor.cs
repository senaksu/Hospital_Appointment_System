using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HastaneOtomasyonu.Models
{
    public class Doktor
    {
        [Key]
        public string Id { get; set; }

        [Required(ErrorMessage = "Boş geçmeyiniz")]
        public string doktoradi { get; set; }

        [ForeignKey("Poliklinik")]
        public int PoliklinikID { get; set; }

        public  Poliklinik poliklinik { get; set; }
        
        [Required(ErrorMessage ="Admin bunu boş geçme")]        
        public int muayeneucreti { get; set; }  

    
    
    }
}
