using SCS.Models;

namespace SCSBlog.Models;
public record DetailPageModel(BlogPost BlogPost, BlogPost[] RelatedPosts)
{
    public static DetailPageModel Empty() => new DetailPageModel(default, []);

    public bool IsEmpty => BlogPost is null;
}
