using SCS.Data;
using SCS.Models;
using SCS.Repository.IRepository;

namespace SCS.Repository;

internal class BundleRepository : Repository<Bundle>, IBundleRepository
{
    private ApplicationDbContext _db;

    public BundleRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }


    public void Update(Bundle bundle)
    {
        _db.Update(bundle);
    }
}
