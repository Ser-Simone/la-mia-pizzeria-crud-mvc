using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pizzeria_Simone.Models
{
    public class Pizza
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Il campo titolo è obbligatorio")]
        [StringLength(10, ErrorMessage ="Il titolo non può avere più di 10 caratteri")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Il campo descrizione è obbligatorio")]
        [Column(TypeName = "Text")]
        public string Description { get; set; }

        [Required(ErrorMessage = "L'Url è obbligatorio")]
        [Url(ErrorMessage = "Mi dispiace, l'url non è valido")]
        public string Image { get; set; }
        public double Price { get; set; }


        public Pizza()
        {

        }

        public Pizza(string title, string description, string image, double price)
        {
            this.Title = title;
            this.Description = description; 
            this.Image = image;
            this.Price = price;

        }

      
    }
}
