using Organizations.Contracts.Models;
using Organizations.Contracts.Models.Abstractions;
using Organizations.Contracts.Services.Abstractions;

namespace Organizations.Contracts.Services
{
    public interface IOrganizationService<TEntity, TDto> : IClassifierBaseService<TEntity, TDto>
    where TEntity : IClassifierEntry
    where TDto : IClassifierDto<Guid>
    {
        public Task<OrganizationTreeItem[]> GetTreeAsync();
    }
}
