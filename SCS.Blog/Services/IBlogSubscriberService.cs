using SCS.Blog.Models;
using SCS.Models;

namespace SCS.Blog.Services;
	public interface IBlogSubscriberService
	{
		Task<string?> BlogSubscriberAsync(BlogSubscriber blogSubscriber);
		Task<PagedResult<BlogSubscriber>> GetBlogSubscribersAsync(int startIndex, int pageSize);

    }
