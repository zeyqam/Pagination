using Fiorello_PB101.Models;
using Fiorello_PB101.Services;
using Fiorello_PB101.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Fiorello_PB101.ViewComponents
{
    public class FooterViewComponent:ViewComponent
    {
        private readonly IFooterService _footerService;
        public FooterViewComponent(IFooterService footerService)
        {
            _footerService = footerService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult(View(await _footerService.GetFooterDataAsync()));
        }
    }
}
public class FooterVMVC
{
    public List<FooterLink> FooterLinks { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}
