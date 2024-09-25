using SCSMock.Data;
using SCSMock.Models;
using SCSMock.Repository.IRepository;

namespace SCSMock.Repository
{
    internal class AddressRepository : Repository<Address>, IAddressRepository
    {
        private ApplicationDbContext _db;

        public AddressRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Address address)
        {
            _db.Addresses.Update(address);
        }
    }
}
