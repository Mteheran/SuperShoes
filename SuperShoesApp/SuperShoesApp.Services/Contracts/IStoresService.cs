﻿using ShuperShoesApp.Entities;
using ShuperShoesApp.Entities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperShoesApp.Services.Contracts
{
    public interface IStoresService
    {
        Task<ResultStores> Get();
        Task<ResultStore> Get<T>(int Id);
        Task<Result> Create<T>(T Item);
        Task<Result> Edit<T>(T Item);
        Task<Result> Delete<T>(int id);
    }
}
