
using Book_Store_Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Book_Store_Data.Repository
{
    public class Repository<T> : IRepository<T> where T:class 
    {
        private readonly DataDbContext _dbContext;
        internal DbSet<T> dbset;
        public Repository(DataDbContext dbContext)
        {
            _dbContext = dbContext;
            this.dbset = _dbContext.Set<T>();  //  dbset == _dbcontext.Set<T>(); == _dbcontext.Categories
        }
        public void Add(T entity)
        {
            dbset.Add(entity);
        }

        public T Get(System.Linq.Expressions.Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbset;
            query = query.Where(filter);
            return query.FirstOrDefault()!;
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbset;
            return query.ToList();
        }

        public void Remove(T entity)
        {
            dbset.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            dbset.RemoveRange(entities);
        }


    }
}
