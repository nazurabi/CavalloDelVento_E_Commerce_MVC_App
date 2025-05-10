using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CavalloDelVentoWebApp.Models
{
    public class Category:Entity
    {
        public Category()
        {
            isDeleted = false;
            isActive = true;
        }
        [Display(Name = "Category Name")]

        [Required(ErrorMessage = "This field can not blank!")]
        [StringLength(maximumLength: 50, ErrorMessage = "This field can be a maximum of 50 characters!")]
        public string categoryName { get; set; }

        public int brand_ID { get; set; }

        [ForeignKey("brand_ID")]
        public virtual Brand brand { get; set; }

        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        [StringLength(maximumLength: 500, ErrorMessage = "This field can be a maximum of 500 characters!")]
        public string description { get; set; }

        [Display(Name = "Is Category Active For Sale")]
        public bool isActive { get; set; }

        public string image { get; set; }

        public virtual ICollection<Product> products { get; set; }

    }
}