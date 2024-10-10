using System.ComponentModel.DataAnnotations;

namespace SCS.Models.ViewModels
{
    public class BookingVM
    {
        [Required]
        public string VoucherId { get; set; }

        public OrderDetails OrderDetails { get; set; }

        public bool VoucherValidated { get; set; }
        
        public IEnumerable<CertificationSlot> Slots { get; set; }
    }
}
