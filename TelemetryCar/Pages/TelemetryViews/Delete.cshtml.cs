using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TelemetryCar.Model;

namespace TelemetryCar.Pages.TelemetryViews
{
    public class DeleteModel : PageModel
    {
        private readonly TelemetryCar.Data.TelemetryCarContext _context;

        public DeleteModel(TelemetryCar.Data.TelemetryCarContext context)
        {
            _context = context;
        }

        [BindProperty] public TelemetryModel TelemetryModel { get; set; }

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TelemetryModel = await _context.TelemetryModel.FindAsync(id);

            if (TelemetryModel != null)
            {
                _context.TelemetryModel.Remove(TelemetryModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}