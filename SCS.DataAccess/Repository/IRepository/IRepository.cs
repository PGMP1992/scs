using System.Linq.Expressions;

namespace SCSMock.Repository.IRepository;

public interface IRepository<T> where T : class
{
    IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
    T Get(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = false);
    void Add(T entity);
    bool Any(Expression<Func<T, bool>> filter);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entity);
}
