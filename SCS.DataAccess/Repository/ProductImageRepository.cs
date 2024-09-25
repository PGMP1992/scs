using SCSMock.Data;
using SCSMock.Models;
using SCSMock.Repository.IRepository;

namespace SCSMock.Repository
{
    internal class ProductImageRepository : Repository<ProductImage>, IProductImageRepository
    {
        private ApplicationDbContext _db;

        public ProductImageRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(ProductImage productImage)
        {
            _db.Update(productImage);
        }
    }
}
