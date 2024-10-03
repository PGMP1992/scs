using System.ComponentModel.DataAnnotations;

namespace SCS.Models
{
    public class Booking
    {
        public int Id { get; set; }

        [Required]
        public AppUser AppUser { get; set; }
        
        [Required]
        public int CertificationSlotId {  get; set; }
        
        [Required]
        public int ProductId { get; set; }
    }
}
