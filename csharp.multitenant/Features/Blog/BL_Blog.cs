using System.Net;
using csharp.multitenant.Models.Features;
using csharp.multitenant.Models.Features.Blog;

namespace csharp.multitenant.Features.Blog;

public class BL_Blog
{
    private readonly DA_Blog _dA_Blog;

    public BL_Blog(DA_Blog dA_Blog)
    {
        _dA_Blog = dA_Blog;
    }

    public async Task<Result<BlogListResponseModelV1>> GetBlogListAsync(
        int pageNo,
        int pageSize,
        CancellationToken cs = default
    )
    {
        Result<BlogListResponseModelV1> result;
        try
        {
            if (pageNo <= 0)
            {
                result = Result<BlogListResponseModelV1>.FailureResult("Page No cannot be null.");
                goto result;
            }

            if (pageSize <= 0)
            {
                result = Result<BlogListResponseModelV1>.FailureResult("Page Size cannot be null.");
                goto result;
            }

            result = await _dA_Blog.GetBlogListAsync(pageNo, pageSize, cs);
        }
        catch (Exception ex)
        {
            result = Result<BlogListResponseModelV1>.FailureResult(
                ex.ToString(),
                HttpStatusCode.InternalServerError
            );
        }

        result:
        return result;
    }
}
