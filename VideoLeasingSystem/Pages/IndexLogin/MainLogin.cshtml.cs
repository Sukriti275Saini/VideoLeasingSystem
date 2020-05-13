using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VideoLeasingSystem.Pages.MainLogin
{
    public class IndexLoginModel : PageModel
    {
        public IActionResult OnPostUserLoginPage()
        {
            return RedirectToPage("/Users/UserLogin");
        }
        public IActionResult OnPostNewUserPage()
        {
            return RedirectToPage("/Users/NewUser");
        }
        public void OnGet()
        {

        }
    }
}