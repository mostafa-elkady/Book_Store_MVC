using Book_Store_Data.Repository.Interfaces;

namespace Book_Store_Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private DataDbContext _dbcontext;

        public ICategoryRepository categoryRepository { get; private set; }
        public IProductRepository productRepository { get; private set; }

        public UnitOfWork(DataDbContext dbcontext)
        {
            _dbcontext = dbcontext;
            categoryRepository = new CategoryRepository(_dbcontext);
            productRepository = new ProductRepository(dbcontext);
        }

        public void Save()
        {
            _dbcontext.SaveChanges();
        }
    }
}
