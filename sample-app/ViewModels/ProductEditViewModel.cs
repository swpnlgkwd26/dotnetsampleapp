using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sample_app.ViewModels
{
    public class ProductEditViewModel
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        [Display(Name = "Product Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Category is Required")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Description is Required")]
        [StringLength(20, ErrorMessage = "{0} Length Must be between {2} and {1}", MinimumLength = 5)]
        // Doesnot contain space
        public string Description { get; set; }

        [Required(ErrorMessage = "Price is Required")]
        [Range(0, 999)]
        public int Price { get; set; }

        [Required(ErrorMessage = "MfgDate is Required")]
        public DateTime MfgDate { get; set; }
    }
}
