using SCS.Data;
using SCS.Models;
using SCS.Repository.IRepository;

namespace SCS.Repository
{
    internal class AppUserRepository : Repository<AppUser>, IAppUserRepository
    {
        private ApplicationDbContext _db;

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
            return _db.AppUsers.FirstOrDefault(u => u.Id == id).Name;
        }

        public string GetEmail(string id)
        {
            return _db.AppUsers.FirstOrDefault(u => u.Id == id).Email;
        }

        public void SetName(string id,string name)
        {
            _db.AppUsers.FirstOrDefault(u=>u.Id == id).Name = name;
        }

        public void SetEmail(string id, string email) 
        {
            _db.AppUsers.FirstOrDefault(u => u.Id == id).Email = email;
        }
    }
}
