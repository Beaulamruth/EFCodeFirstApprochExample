using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EFCodeFirstApprochExample.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="User Name can't be blank")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Password can't be blank")]
        public string Password { get; set; }
    }
}