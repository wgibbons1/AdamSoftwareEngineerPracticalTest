using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerContact.Models
{
    public class CustomerComment
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public DateTime TimeStamp { get; set; }

        [Required]
        public string Comment { get; set; }
    }
}
