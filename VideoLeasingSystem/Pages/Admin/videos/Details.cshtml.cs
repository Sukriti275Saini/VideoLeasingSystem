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
    public class DetailsModel : PageModel
    {
        private readonly VideoLeasingSystem.Data.VideoSystemDbContext _context;

        public DetailsModel(VideoLeasingSystem.Data.VideoSystemDbContext context)
        {
            _context = context;
        }

        public Video Video { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Video = await _context.Videos.FirstOrDefaultAsync(m => m.VideoId == id);

            if (Video == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
