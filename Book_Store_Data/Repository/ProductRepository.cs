using Book_Store_Data.Repository.Interfaces;
using Book_Store_Models;

namespace Book_Store_Data.Repository
{
    internal class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly DataDbContext _dbcontext;
        public ProductRepository(DataDbContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public void Upadte(Product product)
        {
            _dbcontext.Products.Update(product);
        }
    }
}
