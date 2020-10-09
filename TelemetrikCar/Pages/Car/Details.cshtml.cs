using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TelemetrikCar.Data;
using TelemetrikCar.Model;

namespace TelemetrikCar.Pages.Car
{
    public class DetailsModel : PageModel
    {
        private readonly TelemetrikCar.Data.TelemetrikCarContext _context;

        public DetailsModel(TelemetrikCar.Data.TelemetrikCarContext context)
        {
            _context = context;
        }

        public Model.Car Car { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Car = await _context.Car.FirstOrDefaultAsync(m => m.IdCar == id);

            if (Car == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
