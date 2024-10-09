namespace SCS.Models.ViewModels
{
    public class BookingVM
    {
        public string VoucherId { get; set; }
        public IEnumerable<CertificationSlot> Slots { get; set; }
    }
}
