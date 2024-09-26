using SCS.Models;

namespace SCS.Repository.IRepository
{
    public interface ICartRepository :IRepository<Cart>
    {
        void Update(Cart cart);
    }
}
