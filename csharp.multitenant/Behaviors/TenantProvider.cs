using csharp.multitenant.Configurations.AppSetting;
using Microsoft.Extensions.Options;

namespace csharp.multitenant.Behaviors;

public class TenantProvider
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly AppSetting _appSetting;

    public TenantProvider(IHttpContextAccessor httpContextAccessor, IOptions<AppSetting> setting)
    {
        _httpContextAccessor = httpContextAccessor;
        _appSetting = setting.Value;
    }

    public string TenantId =>
        _httpContextAccessor
            .HttpContext!.Request.Headers[Constants.ApplicationConstants.TenantHeader]
            .ToString();

    public string GetConnectionString() =>
        _appSetting.Tenants.FirstOrDefault(x => x.TenantId == TenantId)?.ConnectionString!;
}
