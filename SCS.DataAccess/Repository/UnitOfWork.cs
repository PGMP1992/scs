using SCS.Data;
using SCS.DataAccess.Repository.IRepository;
using SCS.Repository.IRepository;

namespace SCS.Repository;

public class UnitOfWork : IUnitOfWork
{
    public ICategoryRepository Category { get; private set; }
    public IProductRepository Product { get; private set; }
    public IProductImageRepository ProductImage { get; private set; }
    public IProviderRepository Provider { get; private set; }
    public IAppUserRepository AppUser { get; private set; }
    public IAddressRepository Address { get; private set; }
    public ICertificationSlotRepository CertificationSlot { get; private set; }
    public ICertificationDayRepository CertificationDay { get; private set; }

    public ICartRepository Cart { get; private set; }
    public IOrderHeaderRepository OrderHeader { get; private set; }
    public IOrderDetailsRepository OrderDetails { get; private set; }
    public IBundleRepository Bundle { get; private set; }
    public IBookingRepository Booking { get; private set; }
    

    private ApplicationDbContext _db;

    public UnitOfWork(ApplicationDbContext db)
    {
        _db = db;
        Category = new CategoryRepository(_db);
        Product = new ProductRepository(_db);
        ProductImage = new ProductImageRepository(_db);
        Provider = new ProviderRepository(_db);
        AppUser = new AppUserRepository(_db);
        Address = new AddressRepository(_db);
        CertificationSlot = new CertificationSlotRepository(_db);
        CertificationDay = new CertificationDayRepository(_db);
        Cart = new CartRepository(_db);
        OrderHeader = new OrderHeaderRepository(_db);
        OrderDetails = new OrderDetailsRepository(_db);
        Bundle = new BundleRepository(_db);
        Booking = new BookingRepository(_db);
    }

    public  void Save()
    {
        _db.SaveChanges();
    }
    
    public async Task SaveAsync()
    {
        await _db.SaveChangesAsync();
    }
}
