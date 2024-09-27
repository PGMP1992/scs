using SCS.Data;
using SCS.Models;
using SCS.Repository.IRepository;

namespace SCS.Repository
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
