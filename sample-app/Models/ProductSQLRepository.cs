using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sample_app.Models
{
    public class ProductSQLRepository : IStoreRepository
    {
        private readonly TataPowerDataContext _context;

        public ProductSQLRepository(TataPowerDataContext context)
        {
            _context = context;
        }
        public IEnumerable<Product> Products => _context.Products;
        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public bool DeleteProduct(int id)
        {
            // Search by Id
            var productToBeDeleted = _context.Products.Find(id);
            // Remove Pass
            _context.Products.Remove(productToBeDeleted);
            _context.SaveChanges();
            return true;
        }

        public Product GetProductById(int id)
        {
            return _context.Products.Find(id);
        }

        public bool UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
            return true;
        }
    }
}
