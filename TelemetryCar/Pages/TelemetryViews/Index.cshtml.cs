using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

        public IList<TelemetryModel> TelemetryModel { get; set; }
        [BindProperty(SupportsGet = true)] public string SearchString { get; set; }

        public void OnGet()
        {
            TelemetryModel = _context.TelemetryModel
                .Include(t => t.Car).ToList();
            var telemetry = from t in TelemetryModel
                            select t;
            if (!string.IsNullOrEmpty(SearchString))
            {
                telemetry = telemetry.Where(t => t.Car.Name.ToLower().Contains(SearchString.ToLower()));
            }


            TelemetryModel = telemetry.ToList();
        }
    }
}