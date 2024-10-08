using SCS.Models;

namespace SCS.Repository.IRepository;

public interface ICertificationSlotRepository : IRepository<CertificationSlot>
{
    void Update(CertificationSlot certificationSlot);

}
