using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SCS.Models.ViewModels;

public class BundleVM
{
    public Bundle Bundle {  get; set; }
    [ValidateNever]
    public IEnumerable<SelectListItem> ProductList1 { get; set; }
    [ValidateNever]
    public IEnumerable<SelectListItem> ProductList2 { get; set; }
    [ValidateNever]
    public IEnumerable<SelectListItem> ProductList3 { get; set; }
}
