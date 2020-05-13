using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VideoLeasingSystem.Core;
using VideoLeasingSystem.Data;

namespace VideoLeasingSystem.Pages.Admin.users
{
    public class DetailsModel : PageModel
    {
        private readonly VideoLeasingSystem.Data.VideoSystemDbContext _context;

        public DetailsModel(VideoLeasingSystem.Data.VideoSystemDbContext context)
        {
            _context = context;
        }

        public User User { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            User = await _context.Users.FirstOrDefaultAsync(m => m.UserName == id);

            if (User == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
