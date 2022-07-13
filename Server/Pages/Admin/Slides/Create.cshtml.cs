using Domain.Cms.Slides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Persistence;
using ViewModels.Pages.Admin.Slides;

namespace Server.Pages.Admin.Slides
{
    public class CreateModel : Infrastructure.BasePageModel
    {

        public CreateModel(Persistence.DatabaseContext Context) : base()
        {
            _context = Context;
        }

        private readonly DatabaseContext _context;

        public string ErrorMessage { get; set; }

        [Microsoft.AspNetCore.Mvc.BindProperty]
        public SlideViewModel Slide { get; set; }

        public async System.Threading.Tasks.Task
            <Microsoft.AspNetCore.Mvc.IActionResult> OnGet()
        {

            return Page();
        }

        public async System.Threading.Tasks.Task
            <Microsoft.AspNetCore.Mvc.IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var role = _context.Add(new Slider());

            role.CurrentValues.SetValues(Slide);

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
