using SCS.DataAccess.Data;
using SCS.DataAccess.Repository.IRepository;
using SCS.Models;

namespace SCS.DataAccess.Repository;

internal class ProviderRepository : Repository<Provider>, IProviderRepository
{
    private ApplicationDbContext _db;

    public ProviderRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }


    public void Update(Provider provider)
    {
        _db.Update(provider);
    }
}
