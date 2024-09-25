using SCSMock.Models;

namespace SCSMock.Repository.IRepository;

public interface ICategoryRepository : IRepository<Category>
{
    void Update(Category category);

}
