using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuperShoesApp.Entities
{
    public class ArticlesByStoreViewModel
    {
        public IEnumerable<Article> listArticles { get; set; }
        public int Store_Id { get; set; }
        public Article Default { get; set; }

    }
}
