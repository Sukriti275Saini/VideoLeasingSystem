using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VideoLeasingSystem.Core;
using VideoLeasingSystem.Data;
using VideoLeasingSystem.Data.Model;

namespace VideoLeasingSystem.Pages.Users
{
    public class UserLoginModel : PageModel
    {
        private readonly IUserData repo;

        public UserLoginModel(IUserData repo)
        {
            this.repo = repo;
            LoginDetails = new Login();
        }

        [BindProperty]
        public Login LoginDetails { get; set; }
        public string Message { get; set; }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                Message = repo.CheckUser(LoginDetails);
                if (Message == "found")
                {
                    HttpContext.Session.SetString("name",LoginDetails.UserName);
                    return RedirectToPage("./UserDashboard", new { username = LoginDetails.UserName });
                }
            }
            return Page();
        }
    }
}