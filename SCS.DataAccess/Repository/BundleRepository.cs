using SCSMock.Data;
using SCSMock.Models;
using SCSMock.Repository.IRepository;

namespace SCSMock.Repository;

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
