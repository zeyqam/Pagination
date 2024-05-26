using Fiorello_PB101.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Fiorello_PB101.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArchiveController : Controller
    {
        private readonly ICategoryService _categoryService;
        public ArchiveController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task< IActionResult> CategoryArchive()
        {
            return View(await _categoryService.GetAllArchiveAsync());
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

    }
}
