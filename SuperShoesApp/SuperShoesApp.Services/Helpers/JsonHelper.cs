using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SuperShoesApp.Services.Helpers
{
   public static class JsonHelper
    {
       public static async Task<TResponse> Deserialize<TResponse>(HttpResponseMessage result)
        {
            string response = await result.Content.ReadAsStringAsync();
            TResponse serializedResponse = JsonConvert.DeserializeObject<TResponse>(response);
            return serializedResponse;
        }
    }
}
