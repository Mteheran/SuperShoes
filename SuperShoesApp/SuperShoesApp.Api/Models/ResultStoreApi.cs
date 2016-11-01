using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuperShoesApp.Entities.Results
{
    public class ResultStoreApi : Result
    {
        public SuperShoesApp.Api.Data.Stores store { get; set; }
    }
}
