using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCS.Models;

public class CertificationSlot
{
    public int Id { get; set; }
    
    [Display(Name = "Start Date (yyyy-mm-dd)")]
    public DateTime StartDate { get; set; } = DateTime.Now;
    public DateTime EndDate { get; set; } = DateTime.Now;
    public DayOfWeek DayOfWeek { get; set; }
    
    public List<int> WeekNumbers { get; set; }
    
    public int ParticipantsMax { get; set; }
    
    public int ParticipantsRegistered { get; set; }

    public int ProductId { get; set; }
    
    [ForeignKey("ProductId")]
    [ValidateNever]
    public Product Product { get; set; }
}
