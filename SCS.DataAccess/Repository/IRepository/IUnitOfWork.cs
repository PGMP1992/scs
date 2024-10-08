using SCS.DataAccess.Repository.IRepository;

namespace SCS.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        IProductRepository Product { get; }
        IProviderRepository Provider { get; }
        IProductImageRepository ProductImage { get; }
        ICertificationSlotRepository CertificationSlot { get;}
        ICertificationDayRepository CertificationDay { get; }
        IAppUserRepository AppUser { get; }
        IAddressRepository Address { get; }
        ICartRepository Cart { get; }
        IOrderHeaderRepository OrderHeader { get; }
        IOrderDetailsRepository OrderDetails { get; }
        IBundleRepository Bundle { get; }
        IBookingRepository Booking { get; }

        void Save();

        Task SaveAsync();
        
       
    }
}
