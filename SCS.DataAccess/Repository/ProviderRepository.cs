using SCSMock.Data;
using SCSMock.Models;
using SCSMock.Repository.IRepository;

namespace SCSMock.Repository;

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
