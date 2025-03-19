namespace Organizations.Contracts.Services;

public interface IOrganizationExportService
{
    public Task<string> ExportAsync();
}
