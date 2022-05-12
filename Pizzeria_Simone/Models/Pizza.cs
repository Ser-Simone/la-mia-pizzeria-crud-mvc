using System.ComponentModel.DataAnnotations;

namespace Pizzeria_Simone.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Il campo titolo è obbligatorio")]
        [StringLength(10, ErrorMessage ="Il titolo non può avere più di 10 caratteri")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Il campo descrizione è obbligatorio")]
        public string Description { get; set; }

        [Required(ErrorMessage = "L'Url è obbligatorio")]
        [Url(ErrorMessage = "Mi dispiace, l'url non è valido")]
        public string Image { get; set; }
        public double Price { get; set; }


        public Pizza()
        {

        }

        public Pizza(int id, string Title, string Description, string Image, double Price)
        {
            this.Id = Id;
            this.Title = Title;
            this.Description = Description; 
            this.Image = Image;
            this.Price = Price;

        }

      
    }
}
