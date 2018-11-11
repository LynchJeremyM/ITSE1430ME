// ITSE-1430-20630
// Jeremy Lynch
// 11/20/18

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager
{
    public class ContactItem : IContactItem, IValidatableObject
    {
        // Contact Name
        public string ContactName
        { 
            get => _contactName ?? "";
            set => _contactName = value;
        }
        private string _contactName = "";

        // Contact's email address
        public string EmailAddress
        {
            get => _emailAddress ?? "";
            set => _emailAddress = value;
        }
        private string _emailAddress = "";

        public IEnumerable<ValidationResult> Validate( ValidationContext validationContext )
        {
            if (String.IsNullOrEmpty(ContactName))
                yield return new ValidationResult("Name is required.",
                    new[] { nameof(ContactName) });

            if (String.IsNullOrEmpty(EmailAddress))
                yield return new ValidationResult("Email Address is required.",
                    new[] { nameof(EmailAddress) });
        }

    }
}
