using System.ComponentModel.DataAnnotations;

namespace SCS.Models;

public class CertificationSlot
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Display(Name = "Start Date (yyyy-mm-dd)")]
    public DateTime StartDate { get; set; } = DateTime.Now;

    [Display(Name = "End Date (yyyy-mm-dd)")]
    public DateTime EndDate { get; set; } = DateTime.Now.AddDays(30);

    public DayOfWeek? DayOfWeek { get; set; }

    public List<DateOnly> Dates { get; set; }
}
