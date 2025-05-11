using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CavalloDelVentoWebApp.Models
{
    public class Brand : Entity
    {
        public Brand()
        {
            isDeleted = false;
            isActive = true;
        }
        [Display(Name = "Brand Name")]
        [Required(ErrorMessage = "Brand Name can not blank!")]
        [StringLength(maximumLength: 50, ErrorMessage = "This field can be a maximum of 50 characters!")]
        public string brandName { get; set; }

        [Display(Name = "Is Brand Active For Sale")]
        public bool isActive { get; set; }

        public string image { get; set; }

        public virtual ICollection<Product> products { get; set; }

    }
}