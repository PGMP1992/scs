using SCS.Models;

namespace SCS.Repository.IRepository;

public interface ICertificationDayRepository : IRepository<CertificationDay>
{
    Task UpdateAsync(CertificationDay certificationDay);
    Task UpdateCertDayListAsync(CertificationSlot certificationSlot);

}
