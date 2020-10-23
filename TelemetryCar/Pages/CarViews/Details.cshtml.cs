using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TelemetryCar.Data;
using TelemetryCar.Model;

namespace TelemetryCar.Pages.CarViews
{
    public class DetailsModel : PageModel
    {
        private readonly TelemetryCar.Data.TelemetryCarContext _context;

        public DetailsModel(TelemetryCar.Data.TelemetryCarContext context)
        {
            _context = context;
        }

        public CarModel CarModel { get; set; }

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
    }
}