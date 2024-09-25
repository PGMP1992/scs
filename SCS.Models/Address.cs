using System.ComponentModel.DataAnnotations;

namespace SCSMock.Models
{
    public class Address
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Street1 { get; set; } = "";

        [Required]
        [MaxLength(100)]
        public string Street2 { get; set; } = "";

        [Required]
        [MaxLength(50)]
        public string City { get; set; } = "";

        [Required]
        [MaxLength(50)]
        public string State { get; set; } = "";

        [Required]
        [MaxLength(50)]
        public string Country { get; set; } = "";

        [Required]
        [MaxLength(20)]
        public string Postcode { get; set; } = "";
    }
}
