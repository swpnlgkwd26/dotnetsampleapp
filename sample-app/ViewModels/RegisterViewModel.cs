using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sample_app.ViewModels
{
    public class RegisterViewModel
    {
        public string  FirstName { get; set; }
        public string  LastName { get; set; }
        [Required(ErrorMessage ="Email is Required")]
        [EmailAddress]
        public string  Email { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        public string  Password { get; set; }

        [DataType(DataType.Password)]
        public string  ConfirmPassword { get; set; }
        public string  DrivingLicense { get; set; }
    }
}
