using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuperShoesApp.Entities.Results
{
    public class ResultArticles:Result
    {
        public List<Article> articles { get; set; }
    }
}
