using Organizations.Contracts.Services;

namespace Organizations.Application.Services;

public class OrganizationImportService : IOrganizationImportService
{
    //Десериализуем данные и записываем/изменяем в бд 
    public Task ImportAsync(string data)
    {
        throw new NotImplementedException();
    }
}
