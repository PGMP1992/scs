
using Microsoft.EntityFrameworkCore;
using SCS.Blog.Models;
using SCS.Data;
using SCS.Models;

namespace SCS.Blog.Services;
public class BlogPostAdminService : IBlogPostAdminService
{
    private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

    public BlogPostAdminService(IDbContextFactory<ApplicationDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }
    private async Task<TResult> ExecuteOnContext<TResult>(Func<ApplicationDbContext, Task<TResult>> query)
    {
        using var context = _contextFactory.CreateDbContext();
        return await query.Invoke(context);
    }
    public async Task<PagedResult<BlogPost>> GetBlogPostsAsync(int startIndex, int pageSize)
    {
        return await ExecuteOnContext(async context =>
        {
            var query = context.BlogPosts
            .AsNoTracking();

            var count = await query.CountAsync();

            var records = await query
                        .Include(b => b.BlogCategory)
                        .OrderByDescending(b => b.Id)
                        .Skip(startIndex)
                        .Take(pageSize)
                        .ToArrayAsync();

            return new PagedResult<BlogPost> ( records, count );
        });
    }

    public async Task<BlogPost?> GetBlogPostsByIdAsync(int Id) =>
        await ExecuteOnContext(async context =>
                await context.BlogPosts
                        .AsNoTracking()
                        .Include(b => b.BlogCategory)
                        .FirstOrDefaultAsync(b => b.Id == Id)
    );
    
    private async Task<string> GenerateSlugAsync(BlogPost blogPost)
    {
        return await ExecuteOnContext(async context =>
        {
            string originalSlug = blogPost.Title.ToSlug();
            string slug = blogPost.Title.ToSlug();

            int count =1;
            while(await context.BlogPosts.AsNoTracking().AnyAsync(b => b.Slug == slug))
            {
                slug = $"{originalSlug}-{count++}";
            }
            return slug;
        });
    }

    public async  Task<BlogPost> SaveBlogPostAsync(BlogPost blogPost,string userId)
    {
        return await ExecuteOnContext(async context=>
        {
            if (blogPost.Id == 0)
            {
                //New blog post
                var isDublicateTitle = await context.BlogPosts
                            .AsNoTracking()
                            .AnyAsync(b => b.Title == blogPost.Title);
                if (isDublicateTitle)
                {
                    throw new InvalidOperationException($"Blog posts with Title: {blogPost.Title} already exists.");
                }
                blogPost.Slug = await GenerateSlugAsync(blogPost);
                blogPost.CreatedAt = DateTime.UtcNow;
                blogPost.UserId = userId;

                if (blogPost.IsPublished)
                {
                    blogPost.PublishedAt = DateTime.UtcNow;
                }

                await context.BlogPosts.AddAsync(blogPost);
            }
            else
            {
                //Updating existing post
                var isDublicateTitle = await context.BlogPosts
                            .AsNoTracking()
                            .AnyAsync(b => b.Title == blogPost.Title && b.Id != blogPost.Id);
                if (isDublicateTitle)
                {
                    throw new InvalidOperationException($"Blog posts with Title: {blogPost.Title} already exists.");

                }
                var dbBlog = await context.BlogPosts.FindAsync(blogPost.Id);
                dbBlog.Title=blogPost.Title;
                dbBlog.BlogCategoryId=blogPost.BlogCategoryId;
                dbBlog.IsPublished=blogPost.IsPublished;
                dbBlog.Content=blogPost.Content;
                dbBlog.IsFeatured= blogPost.IsFeatured;
                dbBlog.Introduction=blogPost.Introduction;
                dbBlog.Image=blogPost.Image;
                if(blogPost.IsPublished)
                {
                    if(!dbBlog.IsPublished)
                    {
                        blogPost.PublishedAt = DateTime.UtcNow;

                    }
                    else 
                    {
                        blogPost.PublishedAt = null;
                    }
                }

            }
            await context.SaveChangesAsync();
            return blogPost;
        });
    }
}
