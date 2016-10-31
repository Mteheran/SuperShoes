using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperShoesApp.Services.Contracts
{
    public interface IArticlesService
    {
        Task<IEnumerable<T>> Get<T>();
        Task<T> Get<T>(int Id);
        Task<T> Create<T>(T Item);
        Task<T> Edit<T>(T Item);
        Task<T> Delete<T>(int id);
        Task<IEnumerable<T>> GetByStore<T>(int Id);
    }
}
