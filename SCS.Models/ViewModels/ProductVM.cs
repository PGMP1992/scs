using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SCS.Models.ViewModels
{
    public class ProductVM
    {
        public Product Product { get; set; }
        public string Key { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> CategoryList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> ProviderList { get; set; }
        public IEnumerable<SelectListItem> CertSlotList { get; set; }
    }
}
