using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp.multitenant.Models.Features.Blog
{
    public class BlogModel
    {
        public string BlogId { get; set; } = null!;

        public string BlogTitle { get; set; } = null!;

        public string BlogAuthor { get; set; } = null!;

        public string BlogContent { get; set; } = null!;

        public bool IsDeleted { get; set; }
    }
}
