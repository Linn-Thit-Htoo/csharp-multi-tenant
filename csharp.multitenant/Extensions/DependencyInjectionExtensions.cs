using csharp.multitenant.AppDbContextModels;
using csharp.multitenant.Behaviors;
using csharp.multitenant.Configurations.AppSetting;
using csharp.multitenant.Features.Blog;
using Microsoft.EntityFrameworkCore;

namespace csharp.multitenant.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddDependencies(
        this IServiceCollection services,
        WebApplicationBuilder builder
    )
    {
        return builder
            .Services.AddCommonServices(builder)
            .AddDbContextService(builder)
            .AddBusinessLogicServices()
            .AddDataAccessServices();
    }

    public static IServiceCollection AddCommonServices(
        this IServiceCollection services,
        WebApplicationBuilder builder
    )
    {
        builder
            .Services.AddControllers()
            .AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.PropertyNamingPolicy = null;
            });

        builder
            .Configuration.SetBasePath(builder.Environment.ContentRootPath)
            .AddJsonFile(
                $"appsettings.{builder.Environment.EnvironmentName}.json",
                optional: false,
                reloadOnChange: true
            )
            .AddEnvironmentVariables();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddHealthChecks();
        builder.Services.AddHttpContextAccessor();
        builder.Services.Configure<AppSetting>(builder.Configuration);

        builder.Services.AddTransient<TenantProvider>();

        return services;
    }

    public static IServiceCollection AddDbContextService(
        this IServiceCollection services,
        WebApplicationBuilder builder
    )
    {
        builder.Services.AddDbContext<AppDbContext>(
            (sp, opt) =>
            {
                var tenantProvider = sp.GetRequiredService<TenantProvider>();
                string connectionString = tenantProvider.GetConnectionString();

                opt.UseSqlServer(connectionString);
                opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            }
        );

        return services;
    }

    public static IServiceCollection AddBusinessLogicServices(this IServiceCollection services)
    {
        services.AddScoped<BL_Blog>();

        return services;
    }

    public static IServiceCollection AddDataAccessServices(this IServiceCollection services)
    {
        services.AddScoped<DA_Blog>();

        return services;
    }
}
