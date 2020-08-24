using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerContact.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CustomerContact.Pages.Customers
{
    public class DeleteModel : PageModel
    {
        private CustomerContact.Models.CustomerContext CustomerContext { get; set; }

        public DeleteModel(CustomerContact.Models.CustomerContext customerContext) {
            CustomerContext = customerContext;
        }

        [BindProperty]
        public int CustomerId { get; set; }
        public string CustomerForename { get; set; }
        public string CustomerSurname { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id) {
            if (id == null) {
                return BadRequest();
            }

            Customer customer = await CustomerContext.Customer.FindAsync(id);
            if (customer == null) {
                return NotFound();
            }

            CustomerForename = customer.FirstName;
            CustomerSurname = customer.LastName;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync() {
            Customer customer = await CustomerContext.Customer.FindAsync(CustomerId);
            if (customer == null) {
                return NotFound();
            }

            CustomerContext.Customer.Remove(customer);
            await CustomerContext.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
