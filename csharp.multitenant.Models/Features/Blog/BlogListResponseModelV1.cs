using csharp.multitenant.Models.Features.PageSetting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp.multitenant.Models.Features.Blog
{
    public class BlogListResponseModelV1
    {
        public List<BlogModel> Blogs { get; set; }
        public PageSettingModel PageSetting { get; set; }
    }
}
