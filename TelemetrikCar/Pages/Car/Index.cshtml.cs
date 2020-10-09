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
    public class IndexModel : PageModel
    {
        private readonly TelemetrikCar.Data.TelemetrikCarContext _context;

        public IndexModel(TelemetrikCar.Data.TelemetrikCarContext context)
        {
            _context = context;
        }

        public IList<Model.Car> Car { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public async Task OnGetAsync()
        {
            var car = from m in _context.Car
                select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                car = car.Where(s => s.Name.Contains(SearchString));
            }

            Car = await car.ToListAsync();
        }
    }
}
