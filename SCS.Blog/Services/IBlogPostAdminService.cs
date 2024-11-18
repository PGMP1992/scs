

using SCS.Blog.Models;
using SCS.Models;

namespace SCS.Blog.Services;
public interface IBlogPostAdminService
{
    Task<PagedResult<BlogPost>> GetBlogPostsAsync(int startIndex, int pageSize);
    Task<BlogPost?> GetBlogPostsByIdAsync(int Id); 
    Task<BlogPost> SaveBlogPostAsync(BlogPost blogPost, string userId);
}
