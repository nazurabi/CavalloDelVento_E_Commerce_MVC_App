using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CavalloDelVentoWebApp.Models
{
    public class ManagerRole:Entity
    {
        [Display(Name = "Role Name")]
        [Required(ErrorMessage = "This field can not blank!")]
        public string roleName { get; set; }

        public virtual ICollection<Manager> managers { get; set; }

    }
}