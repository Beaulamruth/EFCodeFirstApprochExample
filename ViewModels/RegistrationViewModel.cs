﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EFCodeFirstApprochExample.ViewModels
{
    public class RegistrationViewModel
    {
        [Required(ErrorMessage ="User Name can't be blank")]
        public string UserName { get; set; }
        [Required(ErrorMessage ="Password can't be blank")]
        public string Password { get; set; }

        [Required(ErrorMessage ="Confirmation Password can't be blank")]
        [Compare("Password",ErrorMessage ="Password and Confirm Password do not match")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage ="Email can't be blank")]
        [EmailAddress(ErrorMessage ="Invalid Email")]
        public string Email { get; set; }
        public string Mobile { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

    }
}