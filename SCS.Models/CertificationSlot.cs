using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace SCS.Models;

public class CertificationSlot
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }


    [DataType(DataType.Date)]
    [Display(Name = "Start Date (yyyy-mm-dd)")]
    public DateOnly StartDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);

    [DataType(DataType.Date)]
    [Display(Name = "End Date (yyyy-mm-dd)")]
    public DateOnly EndDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);

    public DayOfWeek? DayOfWeek { get; set; }
    public bool ShowDays { get; set; }=false;
    public List<DateOnly>? Dates { get; set; }
    
    [ValidateNever]
    public IEnumerable<CertificationDay> CertificationDays { get; set; }
}
