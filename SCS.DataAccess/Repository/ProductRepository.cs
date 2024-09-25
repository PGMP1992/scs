using SCSMock.Data;
using SCSMock.Models;
using SCSMock.Repository.IRepository;

namespace SCSMock.Repository;

internal class ProductRepository : Repository<Product>, IProductRepository
{
    private ApplicationDbContext _db;

    public ProductRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }


    public void Update(Product product)
    {
        _db.Update(product);
    }
}
