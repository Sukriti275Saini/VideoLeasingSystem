using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VideoLeasingSystem.Core;
using VideoLeasingSystem.Data;

namespace VideoLeasingSystem.Pages.Videos
{
    public class VideosListModel : PageModel
    {
        private readonly IVideoData videoData;
        private readonly IUserData userData;

        public IEnumerable<Video> Videos { get; set; }
        [BindProperty]
        public int MovieId { get; set; }
        public VideosListModel(IVideoData videoData,IUserData userData)
        {
            this.videoData = videoData;
            this.userData = userData;
        }
        public void OnGet()
        {
            Videos = videoData.GetAll();
        }


        public IActionResult OnPost() 
        {
            var Username =  HttpContext.Session.GetString("name");
            if(Username == null)
            {
                return RedirectToPage("/Users/UserLogin");
            }
            var UserNewRecord = new UserMovieRecord() {
                User = userData.GetByUserName(Username),
                Video = videoData.GetVideoById(MovieId),
                IssueDate = DateTime.Now,
                ReturnDate = DateTime.Now.AddDays(20),
                DueAmount = 0
            };
            bool res = userData.AddRecord(UserNewRecord);
            if (res)
            {
                userData.commit();
                return RedirectToPage("/Users/UserDashboard", new { username = Username});
            }
            return Page();
        }
    }
}
