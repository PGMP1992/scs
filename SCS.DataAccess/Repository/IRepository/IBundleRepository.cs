using SCSMock.Models;

namespace SCSMock.Repository.IRepository;

public interface IBundleRepository : IRepository<Bundle>
{
    void Update(Bundle bundle);

}
