using ShuperShoesApp.Entities;
using ShuperShoesApp.Entities.Results;
using SuperShoesApp.Services.Contracts;
using SuperShoesApp.Services.Helpers;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace SuperShoesApp.Services
{
    public class StoresService : IStoresService
    {
        string baseUrl;

        public StoresService()
        {
            baseUrl = ConfigurationManager.AppSettings["ApiUrl"] + "services/stores";
        }

        public async Task<ResultStores> Get()
        {

            using (HttpClientService client = new HttpClientService())
            {
                HttpResponseMessage response = await client.GetAsync(baseUrl);
                return await JsonHelper.Deserialize<ResultStores>(response);
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

        public async Task<Result> Create<T>(T Item)
        {

            using (HttpClientService client = new HttpClientService())
            {
                HttpResponseMessage response = await client.PostAsync(baseUrl, Item);
                return await JsonHelper.Deserialize<Result>(response);
            }
        }

        public async Task<Result> Edit<T>(T Item)
        {

            using (HttpClientService client = new HttpClientService())
            {
                HttpResponseMessage response = await client.PutAsync(baseUrl, Item);
                return await JsonHelper.Deserialize<Result>(response);
            }
        }

        public async Task<Result> Delete<T>(int id)
        {

            using (HttpClientService client = new HttpClientService())
            {
                HttpResponseMessage response = await client.PatchAsync(baseUrl + "/" + id, id);
                return await JsonHelper.Deserialize<Result>(response);
            }
        }

    }
}
