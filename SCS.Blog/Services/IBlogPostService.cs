
using SCS.Models;
using SCSBlog.Models;

namespace SCS.Blog.Services;

public interface IBlogPostService
{
    Task<DetailPageModel> GetBlogPostBySlugAsync(string slug);
    Task<BlogPost[]> GetFeaturedBlogPostsAsync(int count, int blogCategoryId = 0);
    Task<BlogPost[]> GetPopularBlogPostsAsync(int count, int blogCategoryId = 0);
    Task<BlogPost[]> GetRecentBlogPostsAsync(int count, int blogCategoryId = 0);
	Task<BlogPost[]> GetBlogPostsAsync(int pageIndex, int pageSize, int blogCategoryId = 0);
	bool IsThereAnyPosts();


	}