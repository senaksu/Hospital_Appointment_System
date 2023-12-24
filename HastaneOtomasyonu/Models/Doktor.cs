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

        
        public int PoliklinikId { get; set; }

     

        virtual public ICollection<Randevu> Randevus { get; set; }  


    }
}
