using Book_Store_Models;

namespace Book_Store_Data.Repository.Interfaces
{
    public interface ICategoryRepository:IRepository<Category>
    {
        //Update
        void Update(Category category);

    }
}
