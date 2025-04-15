using csharp.multitenant.Features.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace csharp.multitenant.Features.Blog
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : BaseController
    {
        private readonly BL_Blog _bL_Blog;

        public BlogController(BL_Blog bL_Blog)
        {
            _bL_Blog = bL_Blog;
        }

        [HttpGet("GetBlogs")]
        public async Task<IActionResult> GetBlogs(int pageNo, int pageSize, CancellationToken cs)
        {
            var result = await _bL_Blog.GetBlogListAsync(pageNo, pageSize, cs);
            return Content(result);
        }
    }
}
