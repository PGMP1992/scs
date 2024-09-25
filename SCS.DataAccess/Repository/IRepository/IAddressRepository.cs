using SCSMock.Models;

namespace SCSMock.Repository.IRepository
{
    public interface IAddressRepository : IRepository<Address>
    {
        void Update(Address address);
    }
}
