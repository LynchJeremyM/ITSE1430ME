/* Jeremy Lynch
 * 11/27/2018
 * ITSE 1430
 */
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Nile
{
    public static class ObjectValidator
    {
        public static IEnumerable<ValidationResult> TryValidate( IValidatableObject value )
        {
            var results = new List<ValidationResult>();

            var context = new ValidationContext(value);

            Validator.TryValidateObject(value, context, results, true);

            return results;
        }

        public static IEnumerable<ValidationResult> Validate( IValidatableObject value )
        {
            var results = new List<ValidationResult>();

            var context = new ValidationContext(value);

            Validator.ValidateObject(value, context, true);

            return results;
        }
    }
}
