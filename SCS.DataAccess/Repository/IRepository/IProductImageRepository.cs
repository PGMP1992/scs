using SCS.Models;

namespace SCS.DataAccess.Repository.IRepository;

public interface IProductImageRepository : IRepository<ProductImage>
{
    void Update(ProductImage productImage);

}
