using SCSMock.Data;
using SCSMock.Models;
using SCSMock.Repository.IRepository;

namespace SCSMock.Repository
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
