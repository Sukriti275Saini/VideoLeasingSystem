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
    public class VideosDetailsModel : PageModel
    {
        private readonly IVideoData vd;
        private readonly IUserData ud;

        public VideosDetailsModel(IVideoData vd, IUserData ud)
        {
            this.vd = vd;
            this.ud = ud;
        }
        public Video VideoData { get; set; }
        
        public void OnGet(int vid)
        {
            VideoData = vd.GetVideoById(vid);
        }

        public IActionResult OnPost(int vid)
        {
            var Username = HttpContext.Session.GetString("name");
            if (string.IsNullOrEmpty(Username))
            {
                return RedirectToPage("/Users/UserLogin");
            }
            var UserNewRecord = new UserMovieRecord()
            {
                User = ud.GetByUserName(Username),
                Video = vd.GetVideoById(vid),
                IssueDate = DateTime.Now,
                ReturnDate = DateTime.Now.AddDays(20),
                DueAmount = 0
            };
            bool res = ud.AddRecord(UserNewRecord);
            if (res)
            {
                ud.commit();
                return RedirectToPage("/Users/UserDashboard", new { username = Username });
            }
            return Page();
        }
    }
}