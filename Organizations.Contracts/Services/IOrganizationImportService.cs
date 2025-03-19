namespace Organizations.Contracts.Services;

public interface IOrganizationImportService
{
    public Task ImportAsync(string data);
}
