using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TelemetryCar.Data;
using TelemetryCar.Model;

namespace TelemetryCar.Pages.CarViews
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
            return Page();
        }

        [BindProperty]
        public CarModel CarModel { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            CarModel.ModifiedAt = DateTime.Now;
            CarModel.CreatedAt = DateTime.Now;
            _context.CarModel.Add(CarModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
