using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ViewModels.Pages.Admin.Slides;

namespace Server.Pages.Admin.Slides
{
    public class EditModel : Infrastructure.BasePageModel
    {
        public EditModel(Persistence.DatabaseContext Context) : base()
        {
            _context = Context;
            Slide = new SlideViewModel();

        }

        private readonly Persistence.DatabaseContext _context;


        [Microsoft.AspNetCore.Mvc.BindProperty]
        public System.Guid Id { get; set; }

        [Microsoft.AspNetCore.Mvc.BindProperty]
        public ViewModels.Pages.Admin.Slides.SlideViewModel Slide { get; set; }



        public async System.Threading.Tasks.Task
            <Microsoft.AspNetCore.Mvc.IActionResult> OnGetAsync(System.Guid? id)
        {
            if (id == null || _context.Sliders == null)
            {
                return NotFound();
            }

            var slide = await _context.Sliders.FirstOrDefaultAsync(m => m.Id == id);
            if (slide == null)
            {
                return NotFound();
            }

            //===Map Properties

            Slide.StartDateTime    = slide.StartDateTime;
            Slide.SubTitle         = slide.SubTitle;
            Slide.MainTitle        = slide.MainTitle;
            Slide.UrlLink          = slide.UrlLink;
            Slide.Description      = slide.Description;
            Slide.FinishDateTime   = slide.FinishDateTime; 
            Slide.IsActive         = slide.IsActive;
            Slide.OrderingNumber   = slide.OrderingNumber;

            //===================
            return Page();

        }
        public async System.Threading.Tasks.Task
            <Microsoft.AspNetCore.Mvc.IActionResult> OnPostAsync(System.Guid Id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var slideToUpdate = await _context.Sliders.FindAsync(Id);

            if (slideToUpdate == null)
            {
                return Page();
            }

            if (await TryUpdateModelAsync<Domain.Cms.Slides.Slider>
                    (
                        slideToUpdate,
                        "SlideViewModel",
                        s => s.StartDateTime  ,
                        s => s.SubTitle       ,
                        s => s.MainTitle      ,
                        s => s.UrlLink        ,
                        s => s.Description    ,
                        s => s.FinishDateTime ,
                        s => s.IsActive       ,
                        s => s.OrderingNumber
                    )           
                )
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return RedirectToPage("./Index");
             
        }


    }
}
