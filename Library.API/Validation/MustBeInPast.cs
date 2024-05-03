using System.ComponentModel.DataAnnotations;

namespace Library.API.Validation
{
    public class MustBeInPast : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var valid = (((DateTime)value) < DateTime.Today);
            if (valid)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Published date must be in the past");
        }
    }
}
