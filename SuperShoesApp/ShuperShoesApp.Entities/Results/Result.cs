using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuperShoesApp.Entities.Results
{
    public class Result
    {
        public bool Success { get; set; }
        public int Error_code { get; set; }
        public string Error_msg { get; set; }
        public int Total_elements { get; set; }
    }

}