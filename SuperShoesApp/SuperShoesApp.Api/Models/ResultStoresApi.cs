using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuperShoesApp.Entities.Results
{
    public class ResultStoresApi : Result
    {
        public List<SuperShoesApp.Api.Data.Stores> stores { get; set; }
    }
}
