using SCSMock.Data;
using SCSMock.Models;
using SCSMock.Repository.IRepository;

namespace SCSMock.Repository
{
    internal class CertificationSlotRepository : Repository<CertificationSlot>, ICertificationSlotRepository
    {
        private ApplicationDbContext _db;

        public CertificationSlotRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(CertificationSlot certificationSlot)
        {
            _db.Update(certificationSlot);
        }
    }
}
