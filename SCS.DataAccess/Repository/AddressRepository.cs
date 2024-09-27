using SCS.DataAccess.Data;
using SCS.DataAccess.Repository.IRepository;
using SCS.Models;

namespace SCS.DataAccess.Repository
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
