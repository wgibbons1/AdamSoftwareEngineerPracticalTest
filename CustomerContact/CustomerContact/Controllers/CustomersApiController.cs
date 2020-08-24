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
    [Route("/api/Customers")]
    public class CustomersApiController : Controller
    {
        private CustomerContext CustomerContext { get; set; }

        public CustomersApiController(CustomerContext customerContext) {
            CustomerContext = customerContext;
        }

        public async Task<IActionResult> Get(int? id) {
            if (id == null) {
                return BadRequest();
            }

            Customer customer = await CustomerContext
                .Customer
                .Include(x => x.CustomerComments)
                .FirstOrDefaultAsync(x => x.CustomerID == id);
            if (customer == null) {
                return NotFound();
            }

            customer.CustomerComments = customer.CustomerComments.OrderByDescending(x => x.TimeStamp).ToList();

            AppContractResolver contractResolver = new AppContractResolver(new Dictionary<Type, IEnumerable<string>>() {
                [typeof(Customer)] = new List<string>() {
                    nameof(Customer.CustomerID),
                    nameof(Customer.CustomerComments)
                },
                [typeof(CustomerComment)] = new List<string>() {
                    nameof(CustomerComment.Comment),
                    nameof(CustomerComment.CustomerId),
                    nameof(CustomerComment.Id),
                    nameof(CustomerComment.TimeStamp)
                }
            });

            return Json(customer, new Newtonsoft.Json.JsonSerializerSettings() { ContractResolver = contractResolver });
        }
    }
}
