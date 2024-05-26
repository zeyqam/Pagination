using Fiorello_PB101.Data;
using Fiorello_PB101.Services.Interfaces;
using Fiorello_PB101.ViewModels.Baskets;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Fiorello_PB101.Controllers
{
   
    public class CartController : Controller
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly AppDbContext _context;
        private readonly IProductService _productService;
        public CartController(IHttpContextAccessor accessor,IProductService productService,AppDbContext context)
        {
            _accessor = accessor;
            _context = context;
            _productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<BasketVM> basketDatas = new();
            if (_accessor.HttpContext.Request.Cookies["basket"] is not null)

            {
                basketDatas = JsonConvert.DeserializeObject<List<BasketVM>>(_accessor.HttpContext.Request.Cookies["basket"]);


            }
            var dbProducts = await _productService.GetAllAsync();

            List<BasketProductVM> basketProducts = new();
            foreach (var item in basketDatas)
            {
                var dbProduct = dbProducts.FirstOrDefault(m => m.Id == item.Id);
                basketProducts.Add(new BasketProductVM
                {
                    Id = dbProduct.Id,
                    Name=dbProduct.Name,
                    Description=dbProduct.Description,
                    CategoryName=dbProduct.Category.Name,
                    MainImage=dbProduct.ProductImages.FirstOrDefault(m=>m.IsMain).Name,
                    Count=item.Count,
                    Price=dbProduct.Price


                });
            }

            BasketDetailVM basketDetail = new BasketDetailVM()
            {
                Products = basketProducts,
                TotalPrice = basketDatas.Sum(m=>m.Count*m.Price),
                TotalCount=basketDatas.Count

            };
            

            return View(basketDetail);
        }
    }
}
