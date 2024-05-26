using Fiorello_PB101.Helpers;
using Fiorello_PB101.Services.Interfaces;
using Fiorello_PB101.ViewModels.Categories;

using Microsoft.AspNetCore.Mvc;

namespace Fiorello_PB101.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> Index(int page=1)
        {
            var products = await _productService.GetAllPaginateAsync(page,4);
            var mappeDatas = _productService.GetMappeDatas(products);
            
            int totalPage=await GetPageAsync(4);


            Paginate<Fiorello_PB101.ViewModels.Products.ProductVM> paginateDatas = new(mappeDatas, totalPage, page);


            return View(paginateDatas);
        }

        private async Task<int> GetPageAsync(int take)
        {
            int productCount = await _productService.GetCountAsync();
            
            return (int)Math.Ceiling((decimal)productCount / take); ;
        }
    }
}
