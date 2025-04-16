using csharp.multitenant.Models.Features.PageSetting;

namespace csharp.multitenant.Models.Features.Blog
{
    public class BlogListResponseModelV1
    {
        public List<BlogModel> Blogs { get; set; }
        public PageSettingModel PageSetting { get; set; }
    }
}
