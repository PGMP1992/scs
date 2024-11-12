using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCS.Models.ViewModels
{
    public class DashboardVM
    {
        public IEnumerable<Product> Products {  get; set; }
        public IEnumerable<OrderDetails> Orders { get; set; }
        public IEnumerable<AppUser> Users { get; set; }
        public IEnumerable<Booking> Bookings { get; set; }
    }
}
