using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TelemetrikCar.Data;
using TelemetrikCar.Model;

namespace TelemetrikCar.Pages.Telemetrik
{
    public class EditModel : PageModel
    {
        private readonly TelemetrikCar.Data.TelemetrikCarContext _context;

        public EditModel(TelemetrikCar.Data.TelemetrikCarContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Model.Telemetrik Telemetrik { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Telemetrik = await _context.Telemetrik.FirstOrDefaultAsync(m => m.IdTel == id);

            if (Telemetrik == null)
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

            _context.Attach(Telemetrik).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TelemetrikExists(Telemetrik.IdTel))
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

        private bool TelemetrikExists(int id)
        {
            return _context.Telemetrik.Any(e => e.IdTel == id);
        }
    }
}
