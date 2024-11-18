
using Microsoft.EntityFrameworkCore;
using SCS.Data;
using SCS.Models;
using SCSBlog.Models;

namespace SCS.Blog.Services;
public class BlogPostService : IBlogPostService
{
    private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

    public BlogPostService(IDbContextFactory<ApplicationDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }
    private async Task<TResult> QueryOnContextAsync<TResult>(Func<ApplicationDbContext, Task<TResult>> query)
    {
        using var context = _contextFactory.CreateDbContext();
        return await query.Invoke(context);
    }
    public async Task<BlogPost[]> GetFeaturedBlogPostsAsync(int count, int blogCategoryId = 0)
    {
        return await QueryOnContextAsync(async context =>
        {
            var query = context.BlogPosts
            .AsNoTracking()
            .Include(p => p.BlogCategory)
            .Include(b => b.User)
            .Where(b=>b.IsPublished );


            if(blogCategoryId > 0)
            {
                query=query.Where(b=>b.BlogCategoryId == blogCategoryId);
            }
            var records= await query
            .Where(b=>b.IsFeatured)
            .OrderBy(_ => Guid.NewGuid())
            .Take(count)
            .ToArrayAsync();

            if (count>records.Length)
            {
                var additonalRecords=await query
				    .Where(b => !b.IsFeatured)
			        .OrderBy(_ => Guid.NewGuid())
			        .Take(count-records.Length)
			        .ToArrayAsync();
                records = [.. records, .. additonalRecords];
			}
            return records;
        });
    }
    public async Task<BlogPost[]> GetPopularBlogPostsAsync(int count, int blogCategoryId = 0)
    {
        return await QueryOnContextAsync(async context =>
        {
        var query = context.BlogPosts
        .AsNoTracking()
        .Include(p => p.BlogCategory)
        .Include(b => b.User)
        .Where(b => b.IsPublished);


        if (blogCategoryId > 0)
       
        {
            query = query.Where(b => b.BlogCategoryId == blogCategoryId);
        }
            return await query.OrderByDescending(b=>b.ViewCount)
            .Take(count)
            .ToArrayAsync();
        });
    }
    public async Task<BlogPost[]> GetRecentBlogPostsAsync(int count, int blogCategoryId = 0)
    {
        
       return await GetPostsAsync(0,count, blogCategoryId);
    }

    public async Task<DetailPageModel> GetBlogPostBySlugAsync(string slug)
    {
      
        return await QueryOnContextAsync(async context =>
        {
            var blogPost = await context.BlogPosts
            .AsNoTracking()
            .Include(b => b.BlogCategory)
            .Include(b => b.User)
            .Where(b=>b.IsPublished)
            .FirstOrDefaultAsync(b=>b.Slug==slug && b.IsPublished);

            if(blogPost is null)
            {
                return DetailPageModel.Empty();
            }

            var relatedPosts = await context.BlogPosts
            .AsNoTracking()
            .Include(b => b.BlogCategory)
            .Include(b => b.User)
            .Where(b => b.BlogCategoryId == blogPost.BlogCategoryId && b.IsPublished)
            .OrderBy(_ => Guid.NewGuid())
            .Take(4)
            .ToArrayAsync();

            return new DetailPageModel(blogPost, relatedPosts);
      
        });
    }

	public async Task<BlogPost[]> GetBlogPostsAsync(int pageIndex, int pageSize, int categoryId = 0)
	{
		return await GetPostsAsync(pageIndex*pageSize, pageSize, categoryId);
	}
	public bool IsThereAnyPosts()
	{
		using var context = _contextFactory.CreateDbContext();
		{
			return context.BlogPosts.Any();

		};
	}
	private async Task<BlogPost[]> GetPostsAsync(int skip,int take,int blogCategoryId = 0)
    {
		return await QueryOnContextAsync(async context =>
		{
			var query = context.BlogPosts
			.AsNoTracking()
			.Include(p => p.BlogCategory)
			.Include(b => b.User)
			.Where(b => b.IsPublished);


			if (blogCategoryId > 0)

			{
				query = query.Where(b => b.BlogCategoryId == blogCategoryId);
			}
			return await query.OrderByDescending(b => b.PublishedAt)
			.Skip(skip)
			.Take(take)
			.ToArrayAsync();
		});
	}
}
