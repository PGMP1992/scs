using System.Linq.Expressions;

namespace SCS.Repository.IRepository;

public interface IRepository<T> where T : class
{
    IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
    Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
    
    T Get(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = false);
    Task<T> GetAsync(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = false);
    
    void Add(T entity);
    Task AddAsync(T entity);
    
    bool Any(Expression<Func<T, bool>> filter);
    Task<bool> AnyAsync(Expression<Func<T, bool>> filter);
    
    void Remove(T entity);
    Task<bool> RemoveAsync(T entity);
    
    void RemoveRange(IEnumerable<T> entity);
    Task<bool> RemoveRangeAsync(IEnumerable<T> entity);
}
