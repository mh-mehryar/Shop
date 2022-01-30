using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IProductRepository:IDisposable
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int ProId);
        bool InsertProduct(Product product);
        bool UpdateProduct(Product product);
        bool DeleteProduct(Product product);
        bool DeleteProduct(int ProId);
        void save();
    }
}
