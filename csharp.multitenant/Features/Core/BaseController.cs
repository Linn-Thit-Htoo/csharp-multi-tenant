using csharp.multitenant.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace csharp.multitenant.Features.Core
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IActionResult Content(object obj)
        {
            return Content(obj.ToJson(), "application/json");
        }
    }
}
