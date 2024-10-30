using System.ComponentModel.DataAnnotations;

namespace SCS.Models.Validations;

public class EndDateHasToBeLaterThenStartDate :ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var certSlot = validationContext.ObjectInstance as CertificationSlot;
        if (certSlot != null)
        {
            if (certSlot.EndDate <= certSlot.StartDate)
            {
                return new ValidationResult($"The end date has to be later than the start date");
            }
        }
       
        return ValidationResult.Success;
    }
}
