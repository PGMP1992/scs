
using SCS.Models;

namespace SCS.Blog.Services
{
    public interface IBlogCategoryService
    {
        Task<BlogCategory[]> GetBlogCategoriesAsync();
        Task<BlogCategory?> GetBlogCategoryBySlugAsync(string slug);
        Task<BlogCategory> SaveBlogCategoryAsync(BlogCategory blogCategory);
    }
}