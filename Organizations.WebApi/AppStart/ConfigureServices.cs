using Organizations.Application.Services;
using Organizations.Contracts.Models;
using Organizations.Contracts.Services;
using Organizations.Domain.Organizations;

namespace Organizations.WebApi.AppStart;

public static class ConfigureServices
{
    /// <summary>
    /// Регистрируем сервисы
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IOrganizationService<Organization, OrganizationTreeItem>, OrganizationService>();
        services.AddScoped<IOrganizationMoveService, OrganizationMoveService>();
        services.AddScoped<IOrganizationExportService, OrganizationExportService>();
        services.AddScoped<IOrganizationImportService, OrganizationImportService>();

        return services;
    }
}
