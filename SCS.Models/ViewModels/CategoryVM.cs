

using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace SCS.Models.ViewModels;

public class CategoryVM
{
    [ValidateNever]
    public Category Category { get; set; }
    [ValidateNever]
    public bool OkToDelete { get; set; }
}
