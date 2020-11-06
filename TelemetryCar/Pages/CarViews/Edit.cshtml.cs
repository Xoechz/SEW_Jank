using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TelemetryCar.Model;

namespace TelemetryCar.Pages.CarViews
{
    public class EditModel : PageModel
    {
        private readonly TelemetryCar.Data.TelemetryCarContext _context;

        public EditModel(TelemetryCar.Data.TelemetryCarContext context)
        {
            _context = context;
        }

        [BindProperty] public CarModel CarModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CarModel = await _context.CarModel.FirstOrDefaultAsync(m => m.IdCar == id);

            if (CarModel == null)
            {
                return NotFound();
            }

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

            CarModel.ModifiedAt = DateTime.Now;
            _context.Attach(CarModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarModelExists(CarModel.IdCar))
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

        private bool CarModelExists(int id)
        {
            return _context.CarModel.Any(e => e.IdCar == id);
        }
    }
}