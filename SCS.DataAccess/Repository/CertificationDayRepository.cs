using Microsoft.EntityFrameworkCore;
using SCS.Data;
using SCS.Models;
using SCS.Repository.IRepository;
using System.Runtime.CompilerServices;

namespace SCS.Repository
{
    public class CertificationDayRepository : Repository<CertificationDay>, ICertificationDayRepository
    {
        private ApplicationDbContext _db;

        public CertificationDayRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<CertificationDay> CreateAsync(CertificationDay obj)
        {
            await _db.CertificationDays.AddAsync(obj);
            await _db.SaveChangesAsync();
            return obj;
        }
        public async Task UpdateAsync(CertificationDay certificationDay)
        {
            _db.Update(certificationDay);
            await _db.SaveChangesAsync();
        }
        public async Task UpdateCertDayListAsync(CertificationSlot certificationSlot)
        {
            DateOnly StartDate = certificationSlot.StartDate;
            DateOnly EndDate = certificationSlot.EndDate;
            int cid = certificationSlot.Id;
            List<CertificationDay> certificationDays= _db.CertificationDays.Where(u=>u.CertSlotId==cid).ToList();
          //  List<CertificationDay> certificationDays = await _db.CertificationDays.Where(u => u.CertSlotId == cid).ToListAsync();
            
            if (certificationDays.Count()>0)
            {
                foreach (CertificationDay day in certificationDays)
                {
                    if (day.Date < StartDate || day.Date > EndDate)
                    {
                        Remove(day);
                    }

                }
            }
           

            TimeOnly time = new TimeOnly(00, 00, 00);
            TimeSpan intervall = EndDate.ToDateTime(time) - StartDate.ToDateTime(time);
            DateOnly newDate = StartDate.AddDays(-1);
            CertificationDay certDay = new CertificationDay();
            for (int i = 0; i < intervall.Days + 1; i++)
            {
                newDate = newDate.AddDays(1);
                if (!certificationDays.Any(day => day.Date == newDate))
                {
                    certDay = new()
                    {
                        Date = newDate,
                        IsCertDay = false,
                        CertSlotId = certificationSlot.Id
                    };
                   await _db.CertificationDays.AddAsync(certDay);
                }


            }
          await  _db.SaveChangesAsync();
           
          
        }
    }
}
