using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SCS.Models
{
    public class Address
    {
        public int Id { get; set; }

        [Required]
        [PersonalData]
        [MaxLength(100)]
        [Display(Name = "Address line 1")]
        public string Street1 { get; set; } = "";

        [PersonalData]
        [MaxLength(100)]
        [Display(Name = "Address line 2")]
        public string? Street2 { get; set; } = "";

        [Required]
        [PersonalData]
        [MaxLength(50)]
        public string City { get; set; } = "";

        [PersonalData]
        [MaxLength(50)]
        public string? State { get; set; } = "";

        [Required]
        [PersonalData]
        [MaxLength(50)]
        public string Country { get; set; } = "";

        [Required]
        [PersonalData]
        [MaxLength(20)]
        public string Postcode { get; set; } = "";
    }
}
