using SCS.DataAccess.Data;
using SCS.DataAccess.Repository.IRepository;
using SCS.Models;

namespace SCS.DataAccess.Repository
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
