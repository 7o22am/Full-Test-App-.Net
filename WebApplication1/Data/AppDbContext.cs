using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Areas.Employess.Models;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<Item> items { get; set; }
        public DbSet<Categorys> Categorys { get; set; }
        public DbSet<Employees> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorys>().HasData(
                new Categorys() { Id = 1, Name = "Select Category" },
                new Categorys() { Id = 2, Name = "Computers" },
                new Categorys() { Id = 3, Name = "Mobiles" },
                new Categorys() { Id = 4, Name = "Electric machines" },
                new Categorys() { Id = 5, Name = "Mobile & Electric machines" },
                new Categorys() { Id = 6, Name = "Mobile & Computers" },
                new Categorys() { Id = 7, Name = "Mobile & Computers & Electric machines2" }
                );
           
            base.OnModelCreating(modelBuilder);
        }

    }


}
