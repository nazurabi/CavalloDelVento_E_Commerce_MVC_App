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

        [Required(ErrorMessage = "This field can not blank!")]
        [StringLength(maximumLength: 50, ErrorMessage = "This field can be a maximum of 50 characters!")]
        public string productName { get; set; }

        [AllowHtml]
        [DataType(DataType.MultilineText)]
        [StringLength(maximumLength: 250, ErrorMessage = "This field can be a maximum of 250 characters!")]
        public string description { get; set; }

        [AllowHtml]
        [DataType(DataType.MultilineText)]
        [StringLength(maximumLength: 50, ErrorMessage = "This field can be a maximum of 50 characters!")]
        public string summary { get; set; }
        public string quantityPerUnit { get; set; }

        [DisplayFormat(DataFormatString = "{0:n0}")]
        public decimal unitPrice { get; set; }
        public short unitsInStock { get; set; }
        public short unitsOnOrder { get; set; }
        public short reorderLevel { get; set; }
        public bool IsRecent { get; set; }
        public bool discontinued { get; set; }
        public bool isActive { get; set; }
        public string image { get; set; }

        //public virtual ICollection<Favorite> Favorites { get; set; }
        //public virtual ICollection<Cart> Carts { get; set; }

    }
}