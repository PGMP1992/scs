using SCSMock.Models;

namespace SCSMock.Repository.IRepository
{
    public interface ICartRepository :IRepository<Cart>
    {
        void Update(Cart cart);
    }
}
