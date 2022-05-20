using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Pizzeria_Simone.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatori")]
        [StringLength(75, ErrorMessage = "Il titolo della categorian non puo superare i 75 caratteri")]
        public string Title { get; set; }

        [JsonIgnore]
        public List<Pizza> Pizzas { get; set; }

        public Category()
        {

        }
    }
}