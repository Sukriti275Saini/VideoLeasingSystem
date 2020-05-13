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
    public class SelectVideoModel : PageModel
    {
        private readonly IVideoData videoData;

        public SelectVideoModel(IVideoData videoData)
        {
            this.videoData = videoData;
        }

        public IEnumerable<Video> Videos { get; set; }
        
        [BindProperty(SupportsGet =true)]
        public string SearchVideo { get; set; }
        
        public void OnGet()
        {
            Videos = videoData.GetVideoByName(SearchVideo);
        }
    }
}