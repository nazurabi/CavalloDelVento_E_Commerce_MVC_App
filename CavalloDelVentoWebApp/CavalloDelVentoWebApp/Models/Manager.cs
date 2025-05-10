using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CavalloDelVentoWebApp.Models
{
    public class Manager:Entity
    {
        public int managerRole_ID { get; set; }

        [ForeignKey("managerRole_ID")]
        public virtual ManagerRole managerRole { get; set; }

        [StringLength(maximumLength: 50, ErrorMessage = "This field can be a maximum of 50 characters!")]
        [Required(ErrorMessage = "This field can not blank!")]
        public string subDealerName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "This field can not blank!")]
        [StringLength(maximumLength: 100, MinimumLength = 5, ErrorMessage = "This field can be between 5 and 100 characters!")]
        public string mail { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This field can not blank!")]
        [StringLength(maximumLength: 20, MinimumLength = 5, ErrorMessage = "This field can be between 5 and 20 characters!")]
        public string password { get; set; }

        public bool isActive { get; set; }


    }
}