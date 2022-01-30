using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Product
    {
        [Key]
        public int Pro_Id { get; set; }

        [Display(Name = "دسته بندی کالا")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Cat_Id { get; set; }

        [Display(Name = "نام کالا")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150)]
        public string Pro_Title { get; set; }

        [Display(Name = "کد کالا")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Pro_Code { get; set; }

        [Display(Name = "توضیحات ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(350)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "نمایش کالا")] 
        public bool Is_Active { get; set; }

        [Display(Name = "تصویر کالا")]
        public string Image { get; set; }

        public virtual Category Category{ get; set; }
        public Product()
        {

        }
    }
}
