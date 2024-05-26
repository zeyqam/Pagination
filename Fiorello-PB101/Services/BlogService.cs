using Fiorello_PB101.Data;
using Fiorello_PB101.Models;
using Fiorello_PB101.Services.Interfaces;
using Fiorello_PB101.ViewModels.Blog;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace Fiorello_PB101.Services
{
    public class BlogService : IBlogService
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public BlogService(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IEnumerable<BlogVM>> GetAllAsync( int? take = null)

        {
            IEnumerable<Blog> blogs;
            if ( take is null)
            {
                blogs = await _context.Blogs.ToListAsync();
            }
            else
            {
                 blogs = await _context.Blogs.Take((int)take).ToListAsync();
            }
            return blogs.Select(m => new BlogVM { Title = m.Title, Description = m.Description, Image = m.Image, CreatedDate = m.CreatedDate.ToString("MM.dd.yyyy") });
        }

        public async Task<Blog> GetByIdAsync(int? id)
        {
            return await _context.Blogs
         .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<bool> ExistAsync(string title,string description)
        {
            return await _context.Blogs.AnyAsync(m => m.Title.Trim() == title.Trim() && m.Description.Trim() == description.Trim());
        }

        public async Task CreateAsync(Blog blog, IFormFile request)
        {
            if (request!=null && request.Length>0)
            {
                string fileName=Guid.NewGuid().ToString()+ "-"+ Path.GetFileName (request.FileName);
                //var uploads = Path.Combine(_env.WebRootPath, "img");
                string path=Path.Combine(fileName,request.FileName);
                using (FileStream fileStream = new (path, FileMode.Create))
                {
                    await request.CopyToAsync(fileStream);
                }
                blog.Image = "/img/" + request.FileName;
            }


            await _context.Blogs.AddAsync(blog);
           await _context.SaveChangesAsync();
            

        }

        public async Task DeleteAsync(Blog blog)
        {
            _context.Blogs.Remove(blog);
            await _context.SaveChangesAsync();
        }

        public async Task<BlogVM> GetBlogDetailsAsync(int id)
        {
            var blog= await _context.Blogs.FindAsync(id);
            if (blog==null)
            {
                return null;
            }
            return new BlogVM
            {
                Id=blog.Id,
                Title = blog.Title,
                Description = blog.Description,
                Image = blog.Image,
                CreatedDate = blog.CreatedDate.ToString("MM.dd.yyyy")
            };
        }

        public async Task<IEnumerable<BlogVM>> GetAllWithDetailsAsync()
        {
            var blogs = await _context.Blogs.ToListAsync();
            return blogs.Select(m => new BlogVM
            {
                Id = m.Id,
                Title = m.Title,
                Description = m.Description,
                Image = m.Image,
                CreatedDate = m.CreatedDate.ToString("MM.dd.yyyy")
            });
        }

       

        public async Task UpdateAsync(Blog blog, IFormFile request)
        {
            if (request != null && request.Length > 0)
            {
                
                if (!request.ContentType.Contains("image/"))
                {
                    throw new InvalidOperationException("Yalnız şəkillər yüklənə bilər.");
                }

                
                if (request.Length > 204800)
                {
                    throw new InvalidOperationException("Şəkilin ölçüsü 200 KB-dan böyük ola bilməz.");
                }

                
                string fileName = Guid.NewGuid().ToString() + "-" + Path.GetFileName(request.FileName);
                var uploads = Path.Combine(_env.WebRootPath, "img");
                string filePath = Path.Combine(uploads, fileName);

                
                await using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await request.CopyToAsync(fileStream);
                }

                
                if (!string.IsNullOrEmpty(blog.Image))
                {
                    string oldImagePath = Path.Combine(_env.WebRootPath, blog.Image.TrimStart('/'));
                    if (File.Exists(oldImagePath))
                    {
                        File.Delete(oldImagePath);
                    }
                }

                blog.Image = "/img/" + fileName;
            }

            _context.Blogs.Update(blog);
            await _context.SaveChangesAsync();

        }
    }
    
}
