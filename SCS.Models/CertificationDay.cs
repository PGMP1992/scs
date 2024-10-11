using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCS.Models;

public class CertificationDay
{
    public int Id { get; set; }
    
    public DateOnly Date { get; set; }
    
    public bool IsCertDay { get; set; }

    public int CertSlotId { get; set; }

    [ForeignKey(nameof(CertSlotId))]
    [ValidateNever]
    public CertificationSlot CertificationSlot { get; set; }
}
