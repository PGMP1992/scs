using SCS.Models;

namespace SCS.Repository.IRepository;

public interface IBundleRepository : IRepository<Bundle>
{
    void Update(Bundle bundle);

}
