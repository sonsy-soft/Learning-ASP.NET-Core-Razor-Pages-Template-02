using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Server.Pages.Admin.Slides
{
    public class DetailsModel : Infrastructure.BasePageModel
    {
        private readonly Persistence.DatabaseContext _context;

        public DetailsModel(Persistence.DatabaseContext Context) : base()
        {
            _context = Context;
        }

        public Domain.Cms.Slides.Slider SlideViewModel { get; set; } = default!;

        public async System.Threading.Tasks.Task
            <Microsoft.AspNetCore.Mvc.IActionResult> OnGetAsync(System.Guid? id)
        {
            if (id == null || _context.Sliders == null)
            {
                return NotFound();
            }
            //FirstOrDefaultAsync -> Microsoft.EntityFrameworkCore
            var slide = await _context.Sliders.FirstOrDefaultAsync(m => m.Id == id);
            if (slide == null)
            {
                return NotFound();
            }
            else
            {
                SlideViewModel = slide;
            }
            return Page();
        }
    }
}
