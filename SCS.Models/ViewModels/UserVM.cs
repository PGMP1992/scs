using Microsoft.AspNetCore.Mvc.Rendering;

namespace SCSMock.Models.ViewModels
{
    public class UserVM
    {
        public AppUser AppUser { get; set; }
        public int? AddressId { get; set; }
        public Address Address { get; set; }
        public IEnumerable<SelectListItem> RoleList { get; set; }
    }
}
