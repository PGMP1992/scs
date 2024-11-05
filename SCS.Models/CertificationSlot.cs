using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using SCS.Models.Validations;
using System.ComponentModel.DataAnnotations;

namespace SCS.Models;

public class CertificationSlot
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    [DataType(DataType.Text)]
    public string Name { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [Display(Name = "Start Date (yyyy-mm-dd)")]
    [EndDateHasToBeLaterThenStartDate(ErrorMessage = "End Date has to be later than Start date")]
    public DateOnly StartDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);

    [Required]
    [DataType(DataType.Date)]
    [Display(Name = "End Date (yyyy-mm-dd)")]
    [EndDateHasToBeLaterThenStartDate(ErrorMessage ="End Date has to be later than Start date")]
    public DateOnly EndDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);

    public DayOfWeek? DayOfWeek { get; set; }
    
    public bool ShowDays { get; set; }=false;
    
    public List<DateOnly>? Dates { get; set; }
    
    [ValidateNever]
    public IEnumerable<CertificationDay>? CertificationDays { get; set; }
}
