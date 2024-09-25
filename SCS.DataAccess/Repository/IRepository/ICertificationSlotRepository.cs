using SCSMock.Models;

namespace SCSMock.Repository.IRepository;

public interface ICertificationSlotRepository : IRepository<CertificationSlot>
{
    void Update(CertificationSlot certificationSlot);

}
