using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface ICategoryRepository:IDisposable
    {
        IEnumerable<Category> GetAllCategories();
        Category GetCategoryById(int CatId);
        bool InsertCategory(Category category); 
        bool UpdateCategory(Category category); 
        bool DeleteCategory(Category category); 
        bool DeleteCategory(int CatId);
       void save();
    }
}
