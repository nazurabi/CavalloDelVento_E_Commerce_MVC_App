using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CavalloDelVentoWebApp.Areas.ManagerPanel.Data
{
    public class LoginViewModel
    {
        [Display(Name = "E-Mail")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Mail can not blank!")]
        [StringLength(maximumLength: 100, MinimumLength = 5, ErrorMessage = "E-Mail can be between 5 and 100 characters!")]
        public string mail { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password can not blank!")]
        [StringLength(maximumLength: 20, MinimumLength = 5, ErrorMessage = "Password can be between 5 and 20 characters!")]
        public string password { get; set; }

        public bool rememberMe { get; set; }


    }
}