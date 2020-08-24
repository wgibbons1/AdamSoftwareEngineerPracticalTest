using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CustomerContact.Models;

namespace CustomerContact.Pages.Customers
{
    public class DetailsModel : PageModel
    {
        private readonly CustomerContact.Models.CustomerContext _context;

        public DetailsModel(CustomerContact.Models.CustomerContext context)
        {
            _context = context;
        }

        public Customer Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer = await _context.Customer.FindAsync(id);

            if (Customer == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
