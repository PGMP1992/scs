using SCSMock.Models;

namespace SCSMock.Repository.IRepository;

public interface IProductImageRepository : IRepository<ProductImage>
{
    void Update(ProductImage productImage);

}
