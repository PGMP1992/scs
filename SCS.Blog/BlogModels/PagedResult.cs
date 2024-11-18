
namespace SCS.Blog.Models;
    public record PagedResult<TResult>(TResult[] Records, int TotalCount);
     
    
