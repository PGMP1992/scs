using SCS.Data;
using SCS.Models;
using SCS.Repository.IRepository;

namespace SCS.Repository
{
    internal class CertificationDayRepository : Repository<CertificationDay>, ICertificationDayRepository
    {
        private ApplicationDbContext _db;

        public CertificationDayRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(CertificationDay certificationDay)
        {
            _db.Update(certificationDay);
        }
    }
}
