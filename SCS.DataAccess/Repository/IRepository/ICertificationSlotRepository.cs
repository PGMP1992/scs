using SCS.Models;

namespace SCS.DataAccess.Repository.IRepository;

public interface ICertificationSlotRepository : IRepository<CertificationSlot>
{
    void Update(CertificationSlot certificationSlot);

}
