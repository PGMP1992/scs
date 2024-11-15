namespace SCS.Models.ViewModels
{
    public class DashboardVM
    {
        //public a is new {string Country, int Count}  { get; set; }
        public IEnumerable<IGrouping<string, AppUser>>? Users { get; set; }
        public IEnumerable<IGrouping<Category, Product>>? Products { get; set; }
        public IEnumerable<IGrouping<string, OrderHeader>>? Orders { get; set; }
        public IEnumerable<IGrouping<string, Booking>>? Bookings { get; set; }
    }
}
