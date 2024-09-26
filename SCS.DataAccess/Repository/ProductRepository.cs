using SCS.Data;
using SCS.Models;
using SCS.Repository.IRepository;

namespace SCS.Repository;

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
