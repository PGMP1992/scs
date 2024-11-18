
using Microsoft.EntityFrameworkCore;
using SCS.Data;
using SCS.Models;

namespace SCS.Blog.Services;
public class BlogCategoryService : IBlogCategoryService
{
    private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

    public BlogCategoryService(IDbContextFactory<ApplicationDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    private async Task<TResult> ExecuteOnContext<TResult>(Func<ApplicationDbContext, Task<TResult>> query)
    {
        using var context = _contextFactory.CreateDbContext();
        return await query.Invoke(context);
    }

    public async Task<BlogCategory[]> GetBlogCategoriesAsync()
    {
        return await ExecuteOnContext(async context =>
        {
            var categories = await context.BlogCategories.AsNoTracking().ToArrayAsync();
            return categories;
        });

    }

    public async Task<BlogCategory> SaveBlogCategoryAsync(BlogCategory blogCategory)
    {
        return await ExecuteOnContext(async context =>
        {

            if (blogCategory.Id == 0)
            {
                //new category
                if (await context.BlogCategories.AsNoTracking().AnyAsync(c => c.Name == blogCategory.Name))
                {
                    throw new InvalidOperationException($"BlogCategory with name {blogCategory.Name} already exists");
                }
                blogCategory.Slug = blogCategory.Name.ToSlug();
                await context.BlogCategories.AddAsync(blogCategory);
            }
            else
            {
                //Update
                if (await context.BlogCategories.AsNoTracking().AnyAsync(c => c.Name == blogCategory.Name && c.Id != blogCategory.Id))
                {
                    throw new InvalidOperationException($"BlogCategory with name {blogCategory.Name} already exists");
                }
                BlogCategory? dbBlogCategory = await context.BlogCategories.FindAsync(blogCategory.Id);
                dbBlogCategory.Name = blogCategory.Name;
                dbBlogCategory.ShowOnNavbar = blogCategory.ShowOnNavbar;
                blogCategory.Slug = dbBlogCategory.Slug;

            }
            await context.SaveChangesAsync();
            return blogCategory;
        });

    }
    public async Task<BlogCategory?> GetBlogCategoryBySlugAsync(string slug)
    {
        return await ExecuteOnContext(async context =>
        {
            BlogCategory? blogCategory = await context.BlogCategories.FirstOrDefaultAsync(c => c.Slug == slug);

            if (blogCategory is null)
            {
                blogCategory=await context.BlogCategories.FirstOrDefaultAsync(blogCategory => blogCategory.Id == 1003);
            }
			return blogCategory;
		});
    }

	
}
