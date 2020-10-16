using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TelemetryCar.Data;
using TelemetryCar.Model;

namespace TelemetryCar.Pages.TelemetryViews
{
    public class DetailsModel : PageModel
    {
        private readonly TelemetryCar.Data.TelemetryCarContext _context;

        public DetailsModel(TelemetryCar.Data.TelemetryCarContext context)
        {
            _context = context;
        }

        public TelemetryModel TelemetryModel { get; set; }

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
            return Page();
        }
    }
}
