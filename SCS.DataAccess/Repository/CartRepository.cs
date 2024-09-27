using SCS.DataAccess.Data;
using SCS.DataAccess.Repository.IRepository;
using SCS.Models;

namespace SCS.DataAccess.Repository
{
    public class CartRepository : Repository<Cart>, ICartRepository
    {
        private ApplicationDbContext _db;

        public CartRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Cart cart)
        {
            _db.Carts.Update(cart);
        }
    }
}
