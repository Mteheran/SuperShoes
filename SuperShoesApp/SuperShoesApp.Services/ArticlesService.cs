using SuperShoesApp.Services.Contracts;
using SuperShoesApp.Services.Helpers;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace SuperShoesApp.Services
{
    public class ArticlesService: IArticlesService
    {

          string baseUrl;

          public ArticlesService()
        {
            baseUrl = ConfigurationManager.AppSettings["ApiUrl"] + "services/articles";
        }

        public async Task<IEnumerable<T>> Get<T>()
        {

            using (HttpClientService client = new HttpClientService())
            {
                HttpResponseMessage response = await client.GetAsync(baseUrl);
                return await JsonHelper.Deserialize<IEnumerable<T>>(response);
            }
        }


        public async Task<T> Get<T>(int Id)
        {
            using (HttpClientService client = new HttpClientService())
            {
                HttpResponseMessage response = await client.GetAsync(baseUrl + "/" + Id);
                return await JsonHelper.Deserialize<T>(response);
            }
        }

        public async Task<IEnumerable<T>> GetByStore<T>(int Id)
        {
            using (HttpClientService client = new HttpClientService())
            {
                HttpResponseMessage response = await client.GetAsync(baseUrl + "/stores/" + Id);
                return await JsonHelper.Deserialize<IEnumerable<T>>(response);
            }
        }

        public async Task<T> Create<T>(T Item)
        {

            using (HttpClientService client = new HttpClientService())
            {
                HttpResponseMessage response = await client.PostAsync(baseUrl, Item);
                return await JsonHelper.Deserialize<T>(response);
            }
        }

        public async Task<T> Edit<T>(T Item)
        {

            using (HttpClientService client = new HttpClientService())
            {
                HttpResponseMessage response = await client.PutAsync(baseUrl, Item);
                return await JsonHelper.Deserialize<T>(response);
            }
        }

        public async Task<T> Delete<T>(int id)
        {

            using (HttpClientService client = new HttpClientService())
            {
                HttpResponseMessage response = await client.PatchAsync(baseUrl + "/" + id, id);
                return await JsonHelper.Deserialize<T>(response);
            }
        }
    }
}
