using Fiorello_PB101.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiorello_PB101.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Slider> Sliders { get; set; }
        public DbSet<SliderInfo> SlidersInfos { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<FooterLink> FooterLinks { get; set; }
        public DbSet<ContactInfo> ContactInfos { get; set; }
        public DbSet<LinkItem> LinkItems { get; set; }
        public DbSet<Setting> Settings { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Slider>().HasQueryFilter(m => !m.SofDeleted);
            modelBuilder.Entity<Blog>().HasQueryFilter(m => !m.SofDeleted);
            modelBuilder.Entity<Category>().HasQueryFilter(m => !m.SofDeleted);
            modelBuilder.Entity<Product>().HasQueryFilter(m => !m.SofDeleted);
            modelBuilder.Entity<FooterLink>().HasQueryFilter(m => !m.SofDeleted);
            modelBuilder.Entity<ContactInfo>().HasQueryFilter(m => !m.SofDeleted);
            modelBuilder.Entity<LinkItem>().HasQueryFilter(m => !m.SofDeleted);


            modelBuilder.Entity<Setting>().HasData
                (
                new Setting
                {
                    Id = 1,
                    Key = "Header logo",
                    Value = "logo.png",
                    SofDeleted = false,
                    CreatedDate = DateTime.Now,

                },
                new Setting
                {
                    Id = 2,
                    Key="Phone",
                    Value="3456688",
                    SofDeleted=false,
                    CreatedDate = DateTime.Now,

                },
                new Setting
                {
                    Id = 3,
                    Key = "Address",
                    Value = "Ehmedli",
                    SofDeleted = false,
                    CreatedDate = DateTime.Now,

                }

                );

        }



    }
}
