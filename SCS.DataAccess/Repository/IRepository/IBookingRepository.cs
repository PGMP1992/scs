using SCS.Models;
using SCS.Repository.IRepository;

namespace SCS.DataAccess.Repository.IRepository
{
    public interface IBookingRepository : IRepository<Booking>
    {
        void Update(Booking obj);
    }
}
