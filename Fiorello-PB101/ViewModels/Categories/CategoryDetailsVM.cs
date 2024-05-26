using Fiorello_PB101.Models;

namespace Fiorello_PB101.ViewModels.Categories
{
    public class CategoryDetailsVM
    {

        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string CreatedDate { get; set; }
        public int ProductCount { get; set; }
        public List<ProductVM> Products { get; set; }
    }
}
