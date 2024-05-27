using Fiorello_PB101.Helpers;
using Fiorello_PB101.Services.Interfaces;
using Fiorello_PB101.ViewModels.Categories;
using Microsoft.AspNetCore.Mvc;

namespace Fiorello_PB101.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArchiveController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly  IArchiveService _archiveService;
        public ArchiveController(ICategoryService categoryService, IArchiveService archiveService)
        {
            _categoryService = categoryService;
            _archiveService = archiveService;
        }
        public async Task< IActionResult> CategoryArchive(int page=1)
        {
            var archives = await _archiveService.GetAllPaginateAsync(page, 2);
            var mappeDatas = _archiveService.GetMappedDatas(archives);

            int totalPage = await GetPageAsync(2);


            Paginate<CategoryArchiveVM> paginateDatas = new(mappeDatas, totalPage, page);


            return View(paginateDatas);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RestoreFromArchive(int id)
        {
            try
            {
                await _categoryService.RestoreFromArchiveAsync(id);
                
                return RedirectToAction(nameof(CategoryArchive));
            }
            catch (Exception ex)
            {
                
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction(nameof(CategoryArchive));
            }
        }
        
        private async Task<int> GetPageAsync(int take)
        {
            int productCount = await _archiveService.GetCountAsync();

            return (int)Math.Ceiling((decimal)productCount / take); ;
        }

    }
}
