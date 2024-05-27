using Fiorello_PB101.Models;
using Fiorello_PB101.ViewModels.Categories;

namespace Fiorello_PB101.Services.Interfaces
{
    public interface IArchiveService
    {
        IEnumerable<CategoryArchiveVM> GetMappedDatas(IEnumerable<Category> archives);
        Task<IEnumerable<Category>> GetAllPaginateAsync(int page, int take);
        Task<int> GetCountAsync();
    }
}
