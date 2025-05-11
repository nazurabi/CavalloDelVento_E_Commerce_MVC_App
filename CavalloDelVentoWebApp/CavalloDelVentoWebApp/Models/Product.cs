using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;

namespace CavalloDelVentoWebApp.Models
{
    public class Product : Entity
    {
        public Product()
        {
            isDeleted = false;
            isActive = true;
        }
        public int brand_ID { get; set; }

        [ForeignKey("brand_ID")]
        public virtual Brand brand { get; set; }

        public int category_ID { get; set; }

        [ForeignKey("category_ID")]
        public virtual Category category { get; set; }

        [Required(ErrorMessage = "Product Name can not blank!")]
        [StringLength(maximumLength: 50, ErrorMessage = "This field can be a maximum of 50 characters!")]
        public string productName { get; set; }

        public string productItemNumber { get; set; }

        [AllowHtml]
        [DataType(DataType.MultilineText)]
        [StringLength(maximumLength: 1000, ErrorMessage = "This field can be a maximum of 1000 characters!")]
        public string description { get; set; }

        [AllowHtml]
        [DataType(DataType.MultilineText)]
        [StringLength(maximumLength: 200, ErrorMessage = "This field can be a maximum of 200 characters!")]
        public string summary { get; set; }
        public string quantityPerUnit { get; set; }

        [DisplayFormat(DataFormatString = "{0:n0}")]

        [Display(Name ="Product Unit Price")]
        [Required(ErrorMessage = "Product Unit Price can not blank!")]
        [Range(0, double.MaxValue, ErrorMessage = "Product Unit Price must only be a positive number.")]
        public decimal unitPrice { get; set; }

        [Display(Name = "Product Unit Stock")]
        [Required(ErrorMessage = "Product Unit Stock can not blank!")]
        [Range(0, short.MaxValue, ErrorMessage = "Product Unit Stock must only be a positive number.")]
        public short unitsInStock { get; set; }

        //public short unitsOnOrder { get; set; }
        //public short reorderLevel { get; set; }
        public bool isRecent { get; set; }
        public bool isActive { get; set; }
        public string image { get; set; }

        //public virtual ICollection<Favorite> Favorites { get; set; }
        //public virtual ICollection<Cart> Carts { get; set; }

    }
}