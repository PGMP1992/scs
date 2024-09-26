using SCS.Models;

namespace SCS.Repository.IRepository;

public interface IProductRepository : IRepository<Product>
{
    void Update(Product product);

}
