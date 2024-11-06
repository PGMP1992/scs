using System.ComponentModel.DataAnnotations;

namespace SCS.Models.Validations
{
    internal class NoProductRepeat : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var bundle = validationContext.ObjectInstance as Bundle;

            if (bundle != null)
            {
                if (bundle.Product1.Id == bundle.Product2.Id ||
                    bundle.Product1.Id == bundle.Product3.Id ||
                    bundle.Product2.Id == bundle.Product3.Id)
                {
                    return new ValidationResult("Products must be different!");
                }
            }
            return ValidationResult.Success;
        }
    }
}
