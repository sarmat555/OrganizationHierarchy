using Organizations.Contracts.Services;

namespace Organizations.Application.Services;

public class OrganizationExportService : IOrganizationExportService
{
    //Читаем из БД данные и сериализуем в нужный нам формат
    public Task<string> ExportAsync()
    {
        throw new NotImplementedException();
    }
}
