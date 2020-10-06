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
    public class DetailsModel : PageModel
    {
        private readonly TelemetrikCar.Data.TelemetrikCarContext _context;

        public DetailsModel(TelemetrikCar.Data.TelemetrikCarContext context)
        {
            _context = context;
        }

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
    }
}
