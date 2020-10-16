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
    public class IndexModel : PageModel
    {
        private readonly TelemetryCar.Data.TelemetryCarContext _context;

        public IndexModel(TelemetryCar.Data.TelemetryCarContext context)
        {
            _context = context;
        }

        public IList<TelemetryModel> TelemetryModel { get;set; }

        public async Task OnGetAsync()
        {
            TelemetryModel = await _context.TelemetryModel
                .Include(t => t.Car).ToListAsync();
        }
    }
}
