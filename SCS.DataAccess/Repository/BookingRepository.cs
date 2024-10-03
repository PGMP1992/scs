using SCS.Data;
using SCS.DataAccess.Repository.IRepository;
using SCS.Models;
using SCS.Repository.IRepository;

namespace SCS.Repository
{
    internal class BookingRepository : Repository<Booking>, IBookingRepository
    {
        private ApplicationDbContext _db;

        public BookingRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Booking obj)
        {
            _db.Bookings.Update(obj);
        }
    }
}
