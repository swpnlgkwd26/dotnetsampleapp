using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sample_app.Models
{
    // Contract OF CRUD Operation
    public interface IStoreRepository
    {
        // Return a List Of Product
        IEnumerable<Product> Products { get; }
        Product GetProductById(int id);
        void AddProduct(Product product);
        bool DeleteProduct(int id);

        bool UpdateProduct(Product product);
    }
}
