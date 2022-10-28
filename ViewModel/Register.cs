using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreIdentity.ViewModel
{
    public class Register
    {
        [DataType(DataType.EmailAddress)]
        [Required]
        public string EmaildId { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password",ErrorMessage ="Password and Confirm Password Not Match")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string RoleName { get; set; }

    }
}
