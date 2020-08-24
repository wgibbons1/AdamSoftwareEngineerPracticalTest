using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerContact.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CustomerContact.Pages.Customers
{
    public class EditModel : PageModel
    {
        private CustomerContext CustomerContext { get; set; }

        [BindProperty]
        public Customer Customer { get; set; }

        public EditModel(CustomerContext customerContext) {
            CustomerContext = customerContext;
        }

        public async Task<IActionResult> OnGetAsync(int? id) {
            if (id == null) {
                return BadRequest();
            }

            Customer = await CustomerContext.Customer.FindAsync(id);
            if (Customer == null) {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync() {
            if (!ModelState.IsValid) {
                return Page();
            }

            CustomerContext.Entry(Customer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await CustomerContext.SaveChangesAsync();

            return RedirectToPage("Details", new { Id = Customer.CustomerID });
        }
    }
}
