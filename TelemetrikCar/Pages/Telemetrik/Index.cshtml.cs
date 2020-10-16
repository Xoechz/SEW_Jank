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
    public class IndexModel : PageModel
    {
        private readonly TelemetrikCar.Data.TelemetrikCarContext _context;

        public IndexModel(TelemetrikCar.Data.TelemetrikCarContext context)
        {
            _context = context;
        }

        public IList<Model.Telemetrik> Telemetrik { get;set; }

        public async Task OnGetAsync()
        {
            Telemetrik = await _context.Telemetrik.ToListAsync();
        }
    }
}
