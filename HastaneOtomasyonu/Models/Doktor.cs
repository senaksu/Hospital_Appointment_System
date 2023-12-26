using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HastaneOtomasyonu.Models
{
    public class Doktor
    {

        [Key]
        public int Id { get; set; } 

        [Required(ErrorMessage = "Boş geçmeyiniz")]
        public string doktoradi { get; set; }

       
        
        [Required(ErrorMessage ="Admin bunu boş geçme")]        
        public int muayeneucreti { get; set; }

        [ForeignKey("Poliklinik")]
        public int PoliklinikId { get; set; }
        public Poliklinik poliklinik { get; set; }
     

      //  virtual public ICollection<Randevu> Randevus { get; set; }  


    }
}
