using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Threading.Tasks;
using TelemetryCar.Model;

namespace TelemetryCar.Pages.TelemetryViews
{
    public class CreateModel : PageModel
    {
        private readonly TelemetryCar.Data.TelemetryCarContext _context;

        public CreateModel(TelemetryCar.Data.TelemetryCarContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["CarIdCar"] = new SelectList(_context.CarModel, "IdCar", "IdCar");
            return Page();
        }

        [BindProperty] public TelemetryModel TelemetryModel { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            TelemetryModel.ModifiedAt = DateTime.Now;
            TelemetryModel.CreatedAt = DateTime.Now;
            _context.TelemetryModel.Add(TelemetryModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}