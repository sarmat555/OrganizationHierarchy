using Organizations.Contracts.Models;

namespace Organizations.Contracts.Services
{
    /// <summary>
    /// Интерфейс перемещения организации
    /// </summary>
    public interface IOrganizationMoveService
    {
        public Task MoveAsync(OrganizationMoveDto moved);
    }
}
