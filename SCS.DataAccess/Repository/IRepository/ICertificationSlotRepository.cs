using SCS.Models;

namespace SCS.Repository.IRepository;

public interface ICertificationDayRepository : IRepository<CertificationDay>
{
    void Update(CertificationDay certificationDay);

}
