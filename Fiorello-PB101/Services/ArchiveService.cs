using Fiorello_PB101.Data;
using Fiorello_PB101.Models;
using Fiorello_PB101.Services.Interfaces;
using Fiorello_PB101.ViewModels.Categories;
using Fiorello_PB101.ViewModels.Products;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;

namespace Fiorello_PB101.Services
{
    public class ArchiveService : IArchiveService
    {
        private readonly AppDbContext _context;
        public ArchiveService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllPaginateAsync(int page, int take)
        {
            return await _context.Categories
                                       .IgnoreQueryFilters()
                                       .Where(m => m.SofDeleted)
                                       .OrderByDescending(m => m.Id)
                                       .Skip((page - 1) * take)
                                       .Take(take)
                                       .ToListAsync();
        }

        public async Task<int> GetCountAsync()
        {
            return await _context.Categories.IgnoreQueryFilters()
                                                  .Where(m => m.SofDeleted)
                                                  .CountAsync();
        }

        public IEnumerable<CategoryArchiveVM> GetMappedDatas(IEnumerable<Category> archives)
        {
            return archives.Select(m => new CategoryArchiveVM
            {
                Id = m.Id,
                CategoryName = m.Name,
                CreatedDate = m.CreatedDate.ToString("MM.dd.yyyy")
            });
        }
    }
}
