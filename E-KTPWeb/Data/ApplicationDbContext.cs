using E_KTPWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace E_KTPWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<DataKTP> DataKTP { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DataKTP>().HasData(
                new DataKTP { Id = 1, NIK = 1234567891111113, Name = "Ahmad Subardjo" },
                new DataKTP { Id = 2, NIK = 1232123456787654, Name = "Ahmad Hadsii" },
                new DataKTP { Id = 3, NIK = 1234543212345678, Name = "Surdi Nurdo" }
                );
        }



    }
}
