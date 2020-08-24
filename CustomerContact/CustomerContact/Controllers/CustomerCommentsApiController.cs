using CustomerContact.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace CustomerContact.Controllers
{
    [ApiController]
    [Route("/api/CustomerComments")]
    public class CustomerCommentsApiController : Controller
    {
        private CustomerContext CustomerContext { get; set; }

        public CustomerCommentsApiController(CustomerContext customerContext) {
            CustomerContext = customerContext;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] int? customerId, [FromForm] string comment) {
            if (customerId == null || string.IsNullOrEmpty(comment)) {
                return BadRequest();
            }

            CustomerComment customerComment = new CustomerComment() {
                Comment = comment,
                CustomerId = customerId.Value,
                TimeStamp = DateTime.Now
            };

            CustomerContext.CustomerComments.Add(customerComment);
            await CustomerContext.SaveChangesAsync();

            return Ok(customerComment);
        }
    }
}
