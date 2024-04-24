using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DomainModels.CustomValidations;

namespace DomainModels
{
    public class Product
    {
        [Key]
        [Display(Name = "Product")]
        public long ProductID { get; set; }

        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Product Name can't be blank")]
        [RegularExpression(@"^[A-Za-z0-9 ]*$", ErrorMessage = "Alphabets only")]
        [MaxLength(40, ErrorMessage = "Product Name can be maximum 40 chars long")]
        [MinLength(2, ErrorMessage = "Product Name should contain atleast 2 chars")]
        public string ProductName { get; set; }

        [Display(Name = "Price")]
        [Required]
        [Range(0, 1000000, ErrorMessage = "Price should be in between 1 to 1000000")]
        [DividedBy10(ErrorMessage = "Price should be multiples of 10")]
        public Nullable<decimal> Price { get; set; }

        [Column("DateOfPurchase", TypeName = "datetime")]
        //[DisplayFormat(DataFormatString ="M/d/yyyy",ApplyFormatInEditMode =true)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Date Of Purchase")]
        [DataType(DataType.DateTime)]
        public Nullable<System.DateTime> DateOfPurchase { get; set; }

        [Display(Name = "Availability Status")]
        [Required(ErrorMessage = "Please select Availability Status")]
        public string AvailabilityStatus { get; set; }

        [Display(Name = "Category")]
        [Required]
        public long CategoryID { get; set; }

        [Display(Name = "Brand")]
        [Required]
        public long BrandID { get; set; }

        [Display(Name = "Active")]
        public Nullable<bool> Active { get; set; }

        [Display(Name = "Photo")]
        public string Photo { get; set; }

        [Display(Name = "Quantity")]
        public Nullable<decimal> Quantity { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
    }
}
