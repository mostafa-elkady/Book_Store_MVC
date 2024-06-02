using Book_Store_Models;
using Microsoft.EntityFrameworkCore;

namespace Book_Store_Data
{
    public class DataDbContext : DbContext
    {

        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(

                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Fantasy", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Crime", DisplayOrder = 3 }
            );
        }


    }
}
