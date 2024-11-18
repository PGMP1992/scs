using Microsoft.EntityFrameworkCore;
using SCS.Blog.Models;
using SCS.Data;
using SCS.Models;

namespace SCS.Blog.Services;
public class BlogSubscriberService : IBlogSubscriberService
{
	private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

	public BlogSubscriberService(IDbContextFactory<ApplicationDbContext> contextFactory)
	{
		_contextFactory = contextFactory;
	}



	public async Task<string?> BlogSubscriberAsync(BlogSubscriber blogSubscriber)
	{
		using var context = _contextFactory.CreateDbContext();
		var IsAlreadySubscribed = await context.BlogSubscribers
					.AsNoTracking()
					.AnyAsync(s => s.Email == blogSubscriber.Email);

		if (IsAlreadySubscribed)
		{
			return "You are already subcribed";
		}
		blogSubscriber.SubscribedOn = DateTime.UtcNow;
		await context.BlogSubscribers.AddAsync(blogSubscriber);
		await context.SaveChangesAsync();
		return null;
	}

	public async Task<PagedResult<BlogSubscriber>> GetBlogSubscribersAsync(int startIndex, int pageSize)
	{
		using var context= _contextFactory.CreateDbContext();
		var query=context.BlogSubscribers.AsNoTracking().OrderByDescending(s => s.SubscribedOn);

		var totalCount=await query.CountAsync();
		var records= await query
			.Skip(startIndex)
			.Take(pageSize)
			.ToArrayAsync();
		return new PagedResult<BlogSubscriber>(records, totalCount);
	}

}
