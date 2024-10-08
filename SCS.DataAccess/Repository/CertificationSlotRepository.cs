using Microsoft.EntityFrameworkCore;
using SCS.Data;
using SCS.Models;
using SCS.Repository.IRepository;

namespace SCS.Repository;

internal class CertificationSlotRepository : Repository<CertificationSlot>, ICertificationSlotRepository
{
    private ApplicationDbContext _db;

    public CertificationSlotRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }


    public async Task UpdateAsync(CertificationSlot certificationSlot)
    {
        _db.Update(certificationSlot);
        await _db.SaveChangesAsync();
    }

   
}
