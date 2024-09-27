using SCS.Models;

namespace SCS.Repository.IRepository;

public interface ICategoryRepository : IRepository<Category>
{
    void Update(Category category);

}
