using ShuperShoesApp.Entities;
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
        Task<T> Get<T>(int Id);
        Task<T> Create<T>(T Item);
        Task<T> Edit<T>(T Item);
        Task<T> Delete<T>(int id);
    }
}
