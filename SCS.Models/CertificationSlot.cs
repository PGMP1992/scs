using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCS.Models;

public class CertificationSlot
{
    public int Id { get; set; }
    
    [Display(Name = "Start Date (yyyy-mm-dd)")]
    public DateTime StartDate { get; set; } = DateTime.Now;
    public DateTime EndDate { get; set; } = DateTime.Now.AddDays(30);
    public DayOfWeek? DayOfWeek { get; set; }
    public List<DateOnly>? Dates { get; set; }
    
     
}
