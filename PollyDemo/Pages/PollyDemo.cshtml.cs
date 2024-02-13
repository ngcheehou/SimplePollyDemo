using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace PollyDemo.Pages
{
    public class PollyDemoModel : PageModel
    {
        private readonly MyDbContext _context;
        private readonly IDatabaseRetryService _databaseRetryService;
        public PollyDemoModel(MyDbContext context, IDatabaseRetryService databaseRetryService)
        {
            _context = context;
            _databaseRetryService = databaseRetryService;
        }

        [BindProperty]
        public Employee Employee { get; set; }

        public IList<Employee> Employees { get; set; }

        public async Task OnGetAsync()
        {
            Employees = await _context.Employees.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Employees.Add(Employee);

            await _databaseRetryService.ExecuteWithRetryAsync(async () =>
            {
                await _context.SaveChangesAsync();
            });
            return RedirectToPage("./PollyDemo"); // Redirect to the same page to show the updated list
        }
    }
}
