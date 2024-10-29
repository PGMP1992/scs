using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace SCS.Models.ViewModels
{
    public class BookingVM
    {
        [Required]
        public string VoucherId{ get; set; }

        public string AppUserId { get; set; }

        public AppUser AppUser { get; set; }

        public OrderDetails OrderDetails { get; set; }
        
        public DateOnly BookDate { get; set; }

        public IEnumerable<CertificationSlot> Slots { get; set; }

        [ValidateNever]
        public CertificationSlot CertificationSlot { get; set; }

        [ValidateNever]
        public List<CertificationDay> CDayList { get; set; }
        
        //[ValidateNever]
        //public IEnumerable<CertificationDay> CDayList { get; set; }
    }
}
