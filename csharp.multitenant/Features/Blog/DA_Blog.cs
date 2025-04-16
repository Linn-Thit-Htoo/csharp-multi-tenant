using csharp.multitenant.AppDbContextModels;
using csharp.multitenant.Extensions;
using csharp.multitenant.Models.Features;
using csharp.multitenant.Models.Features.Blog;
using csharp.multitenant.Models.Features.PageSetting;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace csharp.multitenant.Features.Blog
{
    public class DA_Blog
    {
        private readonly AppDbContext _context;
        private readonly ILogger<DA_Blog> _logger;

        public DA_Blog(AppDbContext context, ILogger<DA_Blog> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Result<BlogListResponseModelV1>> GetBlogListAsync(int pageNo, int pageSize, CancellationToken cs = default)
        {
            Result<BlogListResponseModelV1> result;
            try
            {
                var query = _context.TblBlogs.Where(x => !x.IsDeleted);
                var lst = await query
                    .Skip((pageNo - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync(cancellationToken: cs);

                int totalCount = await query.CountAsync(cs);
                int pageCount = totalCount / pageSize;

                if (totalCount % pageSize > 0)
                {
                    pageCount++;
                }

                var pageSetting = new PageSettingModel()
                {
                    PageCount = pageCount,
                    PageNo = pageNo,
                    PageSize = pageSize,
                    TotalCount = totalCount,
                };
                var model = new BlogListResponseModelV1()
                {
                    PageSetting = pageSetting,
                    Blogs = lst.Select(x => x.ToDto()).ToList()
                };

                result = Result<BlogListResponseModelV1>.SuccessResult(model);
            }
            catch (Exception ex)
            {
                result = Result<BlogListResponseModelV1>.FailureResult(ex.ToString(), HttpStatusCode.InternalServerError);
            }

        result:
            return result;
        }
    }
}
