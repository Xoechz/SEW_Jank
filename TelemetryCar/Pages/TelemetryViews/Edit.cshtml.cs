using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TelemetryCar.Data;
using TelemetryCar.Model;

namespace TelemetryCar.Pages.TelemetryViews
{
    public class EditModel : PageModel
    {
        private readonly TelemetryCar.Data.TelemetryCarContext _context;

        public EditModel(TelemetryCar.Data.TelemetryCarContext context)
        {
            _context = context;
        }

        [BindProperty] public TelemetryModel TelemetryModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TelemetryModel = await _context.TelemetryModel
                .Include(t => t.Car).FirstOrDefaultAsync(m => m.IdTel == id);

            if (TelemetryModel == null)
            {
                return NotFound();
            }

            ViewData["CarIdCar"] = new SelectList(_context.CarModel, "IdCar", "IdCar");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            TelemetryModel.ModifiedAt = DateTime.Now;
            _context.Attach(TelemetryModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TelemetryModelExists(TelemetryModel.IdTel))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TelemetryModelExists(int id)
        {
            return _context.TelemetryModel.Any(e => e.IdTel == id);
        }
    }
}