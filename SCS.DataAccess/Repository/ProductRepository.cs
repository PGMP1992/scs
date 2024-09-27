using SCS.DataAccess.Data;
using SCS.DataAccess.Repository.IRepository;
using SCS.Models;

namespace SCS.DataAccess.Repository;

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
