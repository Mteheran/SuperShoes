﻿using ShuperShoesApp.Entities;
using ShuperShoesApp.Entities.Results;
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

        public async Task<ResultArticles> Get()
        {

            using (HttpClientService client = new HttpClientService())
            {
                HttpResponseMessage response = await client.GetAsync(baseUrl);
                return await JsonHelper.Deserialize<ResultArticles>(response);
            }
        }


        public async Task<ResultArticle> Get<T>(int Id)
        {
            using (HttpClientService client = new HttpClientService())
            {
                HttpResponseMessage response = await client.GetAsync(baseUrl + "/" + Id);
                return await JsonHelper.Deserialize<ResultArticle>(response);
            }
        }

        public async Task<ResultArticles> GetByStore(int Id)
        {
            using (HttpClientService client = new HttpClientService())
            {
                HttpResponseMessage response = await client.GetAsync(baseUrl + "/stores/" + Id);
                return await JsonHelper.Deserialize<ResultArticles>(response);
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
