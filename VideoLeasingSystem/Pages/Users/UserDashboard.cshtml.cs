using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VideoLeasingSystem.Core;
using VideoLeasingSystem.Data;

namespace VideoLeasingSystem.Pages.Users
{
    public class UserDashboardModel : PageModel
    {
        private readonly IUserData context;

        public IEnumerable<UserMovieRecord> UserRecord { get; set; }

        public UserDashboardModel(IUserData context)
        {
            this.context = context;
        }

        public void OnGet(string username)
        {
            UserRecord = context.GetRecordsByName(username);
        }

        public IActionResult OnPost()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("UserLogin");
        }
    }
}