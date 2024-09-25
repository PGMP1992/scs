using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SCSMock.Models.ViewModels;

public class CertificationSlotVM
{
    public CertificationSlot CertificationSlot { get; set; }
    [ValidateNever]
    public IEnumerable<SelectListItem> ProductList { get; set; }
  
}
