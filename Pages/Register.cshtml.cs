using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Register_Agen.Model;

namespace Register_Agen.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly AppDbContext _context;

        public RegisterModel(AppDbContext context)
        {
            _context = context;
            Registration = new Registration();
        }

        [BindProperty]
        public Registration Registration { get; set; }

        public void OnGet()
        {
            // Kode yang berhubungan dengan GET request
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            {

                _context.Registrations.Add(Registration);
                await _context.SaveChangesAsync();

                return RedirectToPage("/Success"); // Redirect to a success page after registration.
            }
        }
    }
}

