using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCS.Models
{
    public class Booking
    {
        public int Id { get; set; }

        public string AppUserId { get; set; }

        [ForeignKey("AppUserId")]
        [ValidateNever]
        public AppUser AppUser { get; set; }

        public int CertificationSlotId { get; set; }

        [ForeignKey("CertificationSlotId")]
        [ValidateNever]
        public CertificationSlot CertificationSlot { get; set; }

        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        [ValidateNever]
        public Product Product { get; set; }
    }

}
