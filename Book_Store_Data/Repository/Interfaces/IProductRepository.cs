using Book_Store_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Store_Data.Repository.Interfaces
{
    public interface IProductRepository:IRepository<Product>
    {
        //Update
        void Upadte(Product product);
    }
}
