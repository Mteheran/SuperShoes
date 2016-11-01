using ShuperShoesApp.Entities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperShoesApp.Api.Results
{
    public class ResultArticlesApi:Result
    {
        public List<SuperShoesApp.Api.Data.Articles> articles { get; set; }
    }
}
