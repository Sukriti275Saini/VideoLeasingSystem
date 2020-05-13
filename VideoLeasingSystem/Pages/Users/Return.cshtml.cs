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
    public class ReturnModel : PageModel
    {
        private readonly IUserData ud;
        public ReturnModel(IUserData ud)
        {
            this.ud = ud;
        }

        public UserMovieRecord ReturnDetails { get; set; }

        public IActionResult OnGet(int rid)
        {
            if (HttpContext.Session.GetString("name") == null && string.IsNullOrEmpty(HttpContext.Session.GetString("name")))
                return RedirectToPage("UserLogin");
            ReturnDetails = ud.GetRecordsById(rid);
            return Page();
        }

        public IActionResult OnPost(int rid)
        {
            var user = HttpContext.Session.GetString("name");
            ud.DeleteRecord(rid);
            ud.commit();
            return RedirectToPage("UserDashboard", new { username = user});
        }
    }
}