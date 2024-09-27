using SCS.DataAccess.Data;
using SCS.DataAccess.Repository.IRepository;
using SCS.Models;

namespace SCS.DataAccess.Repository;

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
