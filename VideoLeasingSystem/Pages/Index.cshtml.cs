using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace VideoLeasingSystem.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
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
