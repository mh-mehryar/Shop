using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ProductRepository : IProductRepository
    {
        private MyCmsContext db;
        public ProductRepository(MyCmsContext context)
        {
            this.db = context;
        }
        public IEnumerable<Product> GetAllProducts()
        {
            return db.Products;
        }

        public Product GetProductById(int ProId)
        {
            return db.Products.Find(ProId);
        }

        public bool InsertProduct(Product product)
        {
            try
            {
                db.Products.Add(product);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool UpdateProduct(Product product)
        {
            try
            {
                db.Entry(product).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteProduct(int ProId)
        {
            try
            {
                var pro = GetProductById(ProId);
                DeleteProduct(pro);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteProduct(Product product)
        {
            try
            {
                db.Entry(product).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
