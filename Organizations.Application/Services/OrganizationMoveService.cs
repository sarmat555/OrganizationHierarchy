using Organizations.Application.Context;
using Organizations.Contracts.Models;
using Organizations.Contracts.Services;

namespace Organizations.Application.Services
{
    public class OrganizationMoveService(ApplicationContext _context) : IOrganizationMoveService
    {
        /// <summary>
        /// Перемещение организации
        /// </summary>
        /// <param name="moved"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task MoveAsync(OrganizationMoveDto moved)
        {
            //1) Найдем организацию
            //2) Пересщитаем code и hierarhyPath у организаций, у которых такой же parentId и code >=
            //3) Сохраним в нее новые параметры
            //4) Пересщитаем code и hierarhyPath у организаций, у которых такой же parentId и code >=
            throw new NotImplementedException();
        }
    }
}
