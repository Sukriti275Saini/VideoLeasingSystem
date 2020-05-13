using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VideoLeasingSystem.Core
{
    public class User
    {
        [Key]
        [Required, StringLength(20, MinimumLength = 5)]
        public string UserName { get; set; }

        [Required, StringLength(30, MinimumLength = 3)]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required, StringLength(10)]
        public string PhoneNo { get; set; }

        [Required, StringLength(250)]
        public string Address { get; set; }
    }
}
