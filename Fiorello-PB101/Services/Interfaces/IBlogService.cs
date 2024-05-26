using Fiorello_PB101.Models;
using Fiorello_PB101.ViewModels.Blog;

namespace Fiorello_PB101.Services.Interfaces
{
    public interface IBlogService
    {
        public  Task<IEnumerable<BlogVM>> GetAllAsync(int?take=null);
        Task<Blog> GetByIdAsync(int? id);
        Task<bool> ExistAsync(string title,string description);
        Task CreateAsync(Blog blog,IFormFile request);
        Task DeleteAsync(Blog blog);
        Task<BlogVM> GetBlogDetailsAsync(int id);
        Task<IEnumerable<BlogVM>> GetAllWithDetailsAsync();
        Task UpdateAsync(Blog blog,IFormFile request);

    }
}
