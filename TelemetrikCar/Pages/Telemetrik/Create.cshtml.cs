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
    public class CreateModel : PageModel
    {
        private readonly TelemetrikCar.Data.TelemetrikCarContext _context;

        public CreateModel(TelemetrikCar.Data.TelemetrikCarContext context)
        {
            _context = context;
        }

        

        [BindProperty]
        public Model.Telemetrik Telemetrik { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Telemetrik.ModifiedAt = DateTime.Now;
            Telemetrik.CreatedAt = DateTime.Now;
            _context.Telemetrik.Add(Telemetrik);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
