using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VideoLeasingSystem.Data.Model
{
    public class Login
    {
        [Required(ErrorMessage ="required")]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
