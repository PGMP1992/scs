using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SCS.Models.ViewModels;

public class CertificationSlotVM
{
    [ValidateNever]
    public CertificationSlot CertificationSlot { get; set; }
    
    [ValidateNever]
    public List<CertificationDay> CDayList { get; set; }
}
