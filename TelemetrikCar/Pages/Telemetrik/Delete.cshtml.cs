using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TelemetrikCar.Data;
using TelemetrikCar.Model;

namespace TelemetrikCar.Pages.Telemetrik
{
    public class DeleteModel : PageModel
    {
        private readonly TelemetrikCar.Data.TelemetrikCarContext _context;

        public DeleteModel(TelemetrikCar.Data.TelemetrikCarContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Telemetrik = await _context.Telemetrik.FindAsync(id);

            if (Telemetrik != null)
            {
                _context.Telemetrik.Remove(Telemetrik);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
