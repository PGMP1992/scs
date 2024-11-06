using System.ComponentModel.DataAnnotations;

namespace SCS.Models.Validations
{
    internal class NoProductRepeat : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var bundle = validationContext.ObjectInstance as Bundle;

            //if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            //{
            //    return new ValidationResult("Product is required.");
            //}

            //if (bundle != null)
            //{
            //    if (bundle.ProductId1 == bundle.ProductId2 ||
            //        bundle.ProductId1 == bundle.ProductId3 ||
            //        bundle.ProductId2 == bundle.ProductId3)
            //    {
            //        return new ValidationResult("Products must be different");
            //    }
            //}

            if (bundle != null)
            {
                if (bundle.ProductId1 == bundle.ProductId2 ||
                    bundle.ProductId1 == bundle.ProductId3 ||
                    bundle.ProductId2 == bundle.ProductId3)
                {
                    return new ValidationResult("Products must be different");
                }
            }

            return ValidationResult.Success;
        }
    }
}
