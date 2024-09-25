using SCSMock.Models;

namespace SCSMock.Repository.IRepository;

public interface IProviderRepository : IRepository<Provider>
{
    void Update(Provider provider);

}
