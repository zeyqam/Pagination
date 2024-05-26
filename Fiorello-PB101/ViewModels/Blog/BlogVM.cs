using System.ComponentModel.DataAnnotations;

namespace Fiorello_PB101.ViewModels.Blog
{
    public class BlogVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Input can't be empty")]
        [StringLength(20)]
        public string Title { get; set; }
        [Required(ErrorMessage = "Input can't be empty")]
        [StringLength(250)]
        public string Description { get; set; }
        [Required(ErrorMessage = "Input can't be empty")]
        
        public string Image { get; set; }
        public string CreatedDate { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
