namespace SCS.Models.ViewModels
{
    public class DashboardVM
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<OrderHeader> Orders { get; set; }
        public IEnumerable<AppUser> Users { get; set; }
        public IEnumerable<Booking> Bookings { get; set; }
    }
}
