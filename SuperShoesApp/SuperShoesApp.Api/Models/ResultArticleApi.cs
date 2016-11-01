using ShuperShoesApp.Entities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperShoesApp.Api.Results
{
    public class ResultArticleApi:Result
    {
        public SuperShoesApp.Api.Data.Articles article { get; set; }
    }
}
