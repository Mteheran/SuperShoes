using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShuperShoesApp.Entities
{
    public class Article
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Descripción")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Precio")]
        public double Price { get; set; }

        [Required]
        [Display(Name = "En estante")]
        public int Total_in_shelf { get; set; }

        [Required]
        [Display(Name = "En bóveda")]
        public int Total_in_vault { get; set; }

        [Required]
        [Display(Name = "Tienda")]
        [ForeignKey("Store")]
        public int Store_id { get; set; }

        public virtual Store Stores { get; set; }
    }
}
