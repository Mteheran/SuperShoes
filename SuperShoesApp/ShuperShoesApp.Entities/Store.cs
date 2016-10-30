using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuperShoesApp.Entities
{
    public class Store
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Dirección")]
        public string Address { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}
