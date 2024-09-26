using SCS.Data;
using SCS.Models;
using SCS.Repository.IRepository;

namespace SCS.Repository;

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
