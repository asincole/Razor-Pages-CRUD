using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace razor_pages.Pages
{

    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context;
        private ILogger<CreateModel> _logger;
        public CreateModel(AppDbContext context, ILogger<CreateModel> logger)
        {
            _context = context;
            _logger = logger;
        }
        [TempData]
        public string Message { get; set; }
        [BindProperty]
        public Customer Customer { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Customers.Add(Customer);
            await _context.SaveChangesAsync();
            var msg = $"Customer {Customer.Name} added!";
            Message = msg;
            _logger.LogCritical(msg);
            return RedirectToPage("/Index");

        }
    }
}
