using SCS.Models;

namespace SCS.DataAccess.Repository.IRepository
{
    public interface IAddressRepository : IRepository<Address>
    {
        void Update(Address address);
    }
}
