using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace SCS.Models.ViewModels;

public class ProviderVM
{
    [ValidateNever]
    public Provider Provider { get; set; }
    [ValidateNever]
    public bool OkToDelete { get; set; }
}
