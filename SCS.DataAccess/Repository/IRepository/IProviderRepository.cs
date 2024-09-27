using SCS.Models;

namespace SCS.DataAccess.Repository.IRepository;

public interface IProviderRepository : IRepository<Provider>
{
    void Update(Provider provider);

}
