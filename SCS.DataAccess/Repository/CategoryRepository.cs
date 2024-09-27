using SCS.DataAccess.Data;
using SCS.DataAccess.Repository.IRepository;
using SCS.Models;

namespace SCS.DataAccess.Repository
{
    internal class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(Category category)
        {
            _db.Update(category);
        }
    }
}
