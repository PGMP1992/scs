using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCS.Models
{
    public class AppUser : IdentityUser
    {
        [MaxLength(100)]
        [Required]
        public string? Name { get; set; } = "";

        public int? AddressId {  get; set; }
        
        [ForeignKey(nameof(AddressId))]
        [ValidateNever]
        public Address Address { get; set; }

        [NotMapped]
        public string Role { get; set; } = "";
    }
}
