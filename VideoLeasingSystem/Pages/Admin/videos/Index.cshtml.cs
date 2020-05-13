using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VideoLeasingSystem.Core;
using VideoLeasingSystem.Data;

namespace VideoLeasingSystem.Pages.Admin.videos
{
    public class IndexModel : PageModel
    {
        private readonly VideoLeasingSystem.Data.VideoSystemDbContext _context;

        public IndexModel(VideoLeasingSystem.Data.VideoSystemDbContext context)
        {
            _context = context;
        }

        public IList<Video> Video { get;set; }

        public async Task OnGetAsync()
        {
            Video = await _context.Videos.ToListAsync();
        }
    }
}
