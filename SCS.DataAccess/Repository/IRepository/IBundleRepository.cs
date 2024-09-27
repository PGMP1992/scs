using SCS.Models;

namespace SCS.DataAccess.Repository.IRepository;

public interface IBundleRepository : IRepository<Bundle>
{
    void Update(Bundle bundle);

}
