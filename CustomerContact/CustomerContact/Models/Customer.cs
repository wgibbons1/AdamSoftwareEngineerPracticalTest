using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerContact.Models
{
    public class Customer : IValidatableObject
    {
        public int CustomerID { get; set; }

        [DisplayName("First Name")]
        [Required]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        [Required]
        public string LastName { get; set; }
        [DisplayName("Email Address")]
        [Required]
        public string EmailAddress { get; set; }
        [DisplayName("Address Line 1")]
        [Required]
        public string AddressLine1 { get; set; }
        [DisplayName("Address Line 2")]
        [Required]
        public string AddressLine2 { get; set; }
        [DisplayName("Address City")]
        [Required]
        public string AddressCity { get; set; }
        [DisplayName("Address Postcode")]
        [Required]
        public string AddressPostCode { get; set; }
        [RegularExpression("[0-9]{11}", ErrorMessage ="Phone Number should be 11 characters long with no spaces")]
        [DisplayName("Phone Number")]
        public string ContactNumber { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Date of Birth")]
        [Required]
        public DateTime dateOfBirth { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (EmailAddress.IndexOf('@') <= 0)
            {
                yield return new ValidationResult(
                    $"Email address must contain an @ symbol.",
                    new[] { nameof(EmailAddress) });
            }
        }
    }
}
