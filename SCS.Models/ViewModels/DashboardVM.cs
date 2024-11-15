using NPoco.Expressions;

namespace SCS.Models.ViewModels
{
    public class DashboardVM
    {
        //public a is new {string Country, int Count}  { get; set; }
        public IEnumerable<AppUser>? Users { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<OrderHeader> Orders { get; set; }
        public IEnumerable<Booking> Bookings { get; set; }
    }
}
