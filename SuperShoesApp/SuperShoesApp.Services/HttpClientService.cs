using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SuperShoesApp.Services
{
    public class HttpClientService : IDisposable
    {
        public HttpClientService()
        {

        }

        public async Task<HttpResponseMessage> PostAsync<TRequest>(string serviceUrl, TRequest request)
        {
            using (var client = new HttpClient())
            {
                string bodyRequest = JsonConvert.SerializeObject(request);

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Authorization", GetAuthorizationInfo());

                return await client.PostAsync(serviceUrl, new StringContent(bodyRequest, System.Text.Encoding.UTF8, "application/json"));
            }
        }

        public async Task<HttpResponseMessage> PutAsync<TRequest>(string serviceUrl, TRequest request)
        {
            using (var client = new HttpClient())
            {              
                var bodyRequest = JsonConvert.SerializeObject(request);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Authorization", GetAuthorizationInfo());

                return await client.PutAsync(serviceUrl, new StringContent(bodyRequest, System.Text.Encoding.UTF8, "application/json"));
            }
        }

        public async Task<HttpResponseMessage> GetAsync(string serviceUrl)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Authorization", GetAuthorizationInfo());

                return await client.GetAsync(new Uri(serviceUrl));
            }
        }

        public async Task<HttpResponseMessage> DeleteAsync(string serviceUrl)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Authorization", GetAuthorizationInfo());

                return await client.DeleteAsync(serviceUrl);
            }
        }

        public async Task<byte[]> GetByteArrayAsync(string serviceUrl)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Authorization", GetAuthorizationInfo());

                return await client.GetByteArrayAsync(serviceUrl);
            }
        }

        public async Task<HttpResponseMessage> PatchAsync<TRequest>(string serviceUrl, TRequest request)
        {
            using (var client = new HttpClient())
            {
                var method = new HttpMethod("PATCH");
                var bodyRequest = JsonConvert.SerializeObject(request);
                var requestMessge = new HttpRequestMessage(method, serviceUrl)
                {
                    Content = new StringContent(bodyRequest, System.Text.Encoding.UTF8, "application/json")
                };

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Authorization", GetAuthorizationInfo());


                return await client.SendAsync(requestMessge);
            }
        }

        public void Dispose()
        {

        }

        private string GetAuthorizationInfo()
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(ConfigurationManager.AppSettings["user"])) + ":" + Convert.ToBase64String(Encoding.UTF8.GetBytes(ConfigurationManager.AppSettings["password"]));
        }
    }
}
