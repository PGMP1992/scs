namespace SCS.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        IProductRepository Product { get; }
        IProviderRepository Provider { get; }
        IProductImageRepository ProductImage { get; }
        ICertificationSlotRepository CertificationSlot { get;}
        IAppUserRepository AppUser { get; }
        IAddressRepository Address { get; }
        ICartRepository Cart { get; }
        IOrderHeaderRepository OrderHeader { get; }
        IOrderDetailsRepository OrderDetails { get; }
        IBundleRepository Bundle { get; }

        void Save();
    }
}
