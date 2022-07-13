using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Server.Pages.Admin.Slides
{
    public class DeleteModel : Infrastructure.BasePageModel
    {
        private readonly ILogger<DeleteModel> _logger;

        private readonly Persistence.DatabaseContext _context;

        public DeleteModel(Persistence.DatabaseContext Context, ILogger<DeleteModel> logger) : base()
        {
            _logger = logger;
            _context = Context;
            ErrorMessage = "";
            SlideViewModel = new();
        }

        [Microsoft.AspNetCore.Mvc.BindProperty]
        public System.Guid Id { get; set; }

        public string ErrorMessage { get; set; }

        [Microsoft.AspNetCore.Mvc.BindProperty]
        public ViewModels.Pages.Admin.Slides.SlideViewModel SlideViewModel { get; set; }


        public async System.Threading.Tasks.Task
            <Microsoft.AspNetCore.Mvc.IActionResult> OnGetAsync(System.Guid? id, bool? saveChangesError = false)
        {

            if (id == null || _context.Sliders == null)
            {
                return NotFound();
            }

            //FirstOrDefaultAsync -> using Microsoft.EntityFrameworkCore;
            var slide = await _context.Sliders
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (slide == null)
            {
                return NotFound();
            }

             //===Map Properties

            SlideViewModel.StartDateTime    = slide.StartDateTime;
            SlideViewModel.SubTitle         = slide.SubTitle;
            SlideViewModel.MainTitle        = slide.MainTitle;
            SlideViewModel.UrlLink          = slide.UrlLink;
            SlideViewModel.Description      = slide.Description;
            SlideViewModel.FinishDateTime   = slide.FinishDateTime; 
            SlideViewModel.IsActive         = slide.IsActive;
            SlideViewModel.OrderingNumber   = slide.OrderingNumber;


            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = System.String.Format("Delete {ID} failed. Try again", id);
            }

            return Page();

        }

        public async System.Threading.Tasks.Task
            <Microsoft.AspNetCore.Mvc.IActionResult> OnPostDeleteAsync(System.Guid? Id)
        {

            if (Id == null || _context.Sliders == null)
            {
                return NotFound();
            }

            var slide = await _context.Sliders.FindAsync(Id);
            if (slide == null)
            {
                return NotFound();
            }

            try
            {
                _context.Sliders.Remove(slide);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, ErrorMessage);

                return RedirectToAction("./Delete", new { Id, saveChangesError = true });
            }

        }

    }
}
