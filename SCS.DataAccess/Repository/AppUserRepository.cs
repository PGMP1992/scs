using SCS.Data;
using SCS.Models;
using SCS.Repository.IRepository;

namespace SCS.Repository
{
    internal class AppUserRepository : Repository<AppUser>, IAppUserRepository
    {
        private readonly ApplicationDbContext _db;

        public AppUserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(AppUser appUser)
        {
            _db.AppUsers.Update(appUser);
        }

        public string GetName(string id)
        {
            return _db.AppUsers.FirstOrDefault(u => u.Id == id)?.Name ?? string.Empty;
        }

        public string GetEmail(string id)
        {
            return _db.AppUsers.FirstOrDefault(u => u.Id == id)?.Email ?? string.Empty;
        }

        public void SetName(string id, string name)
        {
            var user = _db.AppUsers.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                user.Name = name;
            }
        }

        public void SetEmail(string id, string email)
        {
            var user = _db.AppUsers.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                user.Email = email;
            }
        }
    }
}
