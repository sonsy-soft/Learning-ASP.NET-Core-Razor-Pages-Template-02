using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Server.Pages.Admin.Slides
{
    public class IndexModel : PageModel
    {
        public IndexModel(Persistence.DatabaseContext Context) : base()
        {
            _context = Context;
        }

        private readonly Persistence.DatabaseContext _context;

        public System.Collections.Generic.IList
            <Domain.Cms.Slides.Slider> Sliders
        { get; set; } = default!;

        public async System.Threading.Tasks.Task
            <Microsoft.AspNetCore.Mvc.IActionResult> OnGetAsync()
        {

            //ToListAsync  -> Microsoft.EntityFrameworkCore
            Sliders = await _context.Sliders.ToListAsync();

            if (Sliders == null)
            {
                return NotFound();
            }

            return Page();
        }

    }
}
