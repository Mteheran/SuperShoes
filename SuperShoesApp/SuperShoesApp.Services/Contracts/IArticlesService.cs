﻿using ShuperShoesApp.Entities;
using ShuperShoesApp.Entities.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperShoesApp.Services.Contracts
{
    public interface IArticlesService
    {
        Task<ResultArticles> Get();
        Task<T> Get<T>(int Id);
        Task<T> Create<T>(T Item);
        Task<T> Edit<T>(T Item);
        Task<T> Delete<T>(int id);
        Task<ResultArticles> GetByStore(int Id);
    }
}
