using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class CategoryRepository : ICategoryRepository
    {
        private MyCmsContext db;
        public CategoryRepository(MyCmsContext context)
        {
            this.db = context;
        }
        public IEnumerable<Category> GetAllCategories()
        {
            return db.Categories;
        }
        public Category GetCategoryById(int CatId)
        {
            return db.Categories.Find(CatId);

        }
        public bool InsertCategory(Category category)
        {
            try
            {
                db.Categories.Add(category);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool UpdateCategory(Category category)
        {
            try
            {
                db.Entry(category).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
       

        public bool DeleteCategory(int CatId)
        {
            try
            {
                var Cat = GetCategoryById(CatId);
                DeleteCategory(Cat);
                return true;
            }
            catch (Exception)
            {

                return false;
            };
        }
        public bool DeleteCategory(Category category)
        {
            try
            {
                db.Entry(category).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {

                return false;
            };
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
