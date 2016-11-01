using ShuperShoesApp.Entities;
using ShuperShoesApp.Entities.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperShoesApp.Services.Contracts
{
    public interface IArticlesService
    {
        Task<ResultArticles> Get();
        Task<ResultArticle> Get<T>(int Id);
        Task<Result> Create<T>(T Item);
        Task<Result> Edit<T>(T Item);
        Task<Result> Delete<T>(int id);
        Task<ResultArticles> GetByStore(int Id);
    }
}
