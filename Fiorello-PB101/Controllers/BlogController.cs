using Fiorello_PB101.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Fiorello_PB101.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        public BlogController( IBlogService blogService)
        {
            _blogService = blogService;
        }
        public async Task< IActionResult> Index()
        {
            return View(await _blogService.GetAllAsync());
        }

        public async Task<IActionResult> Detail(int? id)
        {
            var blog = await _blogService.GetByIdAsync(id);
            if (blog == null)
            {
                return NotFound();
            }
            if (id==null)
            {
                return BadRequest();
            }
            return View(blog);
        }
    }
}
