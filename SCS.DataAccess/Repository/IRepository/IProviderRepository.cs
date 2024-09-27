using SCS.Models;

namespace SCS.Repository.IRepository;

public interface IProviderRepository : IRepository<Provider>
{
    void Update(Provider provider);

}
