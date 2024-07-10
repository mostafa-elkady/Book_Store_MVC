using Book_Store_Data.Repository.Interfaces;
using Book_Store_Models;

namespace Book_Store_Data.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly DataDbContext _dbcontext;

        public CategoryRepository(DataDbContext dbcontext) :base(dbcontext) 
        {
            _dbcontext = dbcontext;
        }
        public void Update(Category category)
        {
            _dbcontext.Categories.Update(category);
        }
    }
}
