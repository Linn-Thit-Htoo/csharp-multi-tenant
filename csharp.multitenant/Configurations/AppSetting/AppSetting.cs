namespace csharp.multitenant.Configurations.AppSetting;

public class AppSetting
{
    public Logging Logging { get; set; }
    public Tenant[] Tenants { get; set; }
}

public class Logging
{
    public Loglevel LogLevel { get; set; }
}

public class Loglevel
{
    public string Default { get; set; }
    public string MicrosoftAspNetCore { get; set; }
}

public class Tenant
{
    public string TenantId { get; set; }
    public string ConnectionString { get; set; }
}
