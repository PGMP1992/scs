using SCS.DataAccess.Data;
using SCS.DataAccess.Repository.IRepository;
using SCS.Models;

namespace SCS.DataAccess.Repository
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
