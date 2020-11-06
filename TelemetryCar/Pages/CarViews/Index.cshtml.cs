using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TelemetryCar.Model;

namespace TelemetryCar.Pages.CarViews
{
    public class IndexModel : PageModel
    {
        private readonly TelemetryCar.Data.TelemetryCarContext _context;

        public IndexModel(TelemetryCar.Data.TelemetryCarContext context)
        {
            _context = context;
        }

        public IList<CarModel> CarModel { get; set; }

        public async Task OnGetAsync()
        {
            CarModel = await _context.CarModel.ToListAsync();
        }
    }
}