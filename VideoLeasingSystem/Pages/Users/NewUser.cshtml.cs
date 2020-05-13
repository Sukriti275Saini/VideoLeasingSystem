using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VideoLeasingSystem.Core;
using VideoLeasingSystem.Data;

namespace VideoLeasingSystem.Pages.Users
{
    public class NewUserModel : PageModel
    {
        private readonly IUserData userSignup;

        public string Message { get; set; }

        [BindProperty]
        public User UserDetails { get; set; }

        public NewUserModel(IUserData userSignup)
        {
            this.userSignup = userSignup;
            UserDetails = new User();
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                Message = userSignup.Add(UserDetails);
                if (Message == "Added")
                {
                    userSignup.commit();
                    HttpContext.Session.SetString("name", UserDetails.UserName);
                    return RedirectToPage("./UserDashboard", new { username = UserDetails.UserName });
                }
            }
            return Page();
        }
    }
}