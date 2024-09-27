using SCS.Models;

namespace SCS.Repository.IRepository
{
    public interface IAppUserRepository : IRepository<AppUser>
    {
        void Update(AppUser appUser);
        string GetName(string id);
        string GetEmail(string id);
        void SetName(string id, string name);
        void SetEmail(string id, string email);
    }
}
