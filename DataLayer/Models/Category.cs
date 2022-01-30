using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Category
    {
        [Key]
        public int Cat_Id { get; set; }

        [Display(Name ="دسته بندی کالا")]
        [Required(ErrorMessage ="لطفا {0} را وارد کنید")]
        [MaxLength(150)]
        public string Cat_Title { get; set; }

        public virtual List<Product>Products { get; set; }
        public Category()
        {

        }
    }
}
