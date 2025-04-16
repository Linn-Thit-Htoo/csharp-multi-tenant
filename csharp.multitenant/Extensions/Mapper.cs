using csharp.multitenant.AppDbContextModels;
using csharp.multitenant.Models.Features.Blog;

namespace csharp.multitenant.Extensions;

public static class Mapper
{
    public static BlogModel ToDto(this TblBlog model)
    {
        return new BlogModel
        {
            BlogId = model.BlogId,
            BlogTitle = model.BlogTitle,
            BlogAuthor = model.BlogAuthor,
            BlogContent = model.BlogContent,
            IsDeleted = model.IsDeleted
        };
    }
}
