using SCS.Models;

namespace SCS.Repository.IRepository;

public interface ICertificationSlotRepository : IRepository<CertificationSlot>
{
    Task UpdateAsync(CertificationSlot certificationSlot);
    
}
