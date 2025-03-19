using Organizations.Contracts.Models;
using Organizations.Domain.Organizations;

namespace Organizations.Contracts.Mappers;

public static class OrganizationMapper
{
    public static IQueryable<OrganizationTreeItem> SelectTreeItem(this IQueryable<Organization> query)
    {
        return query
            .Select(o => new OrganizationTreeItem
            {
                Id = o.Id,
                Name = $"{o.Name} {o.Code}",
                Code = o.Code,
                ParentId = o.ParentId,
                HierarchyPath = o.HierarchyPath
            });
    }

    public static IEnumerable<OrganizationTreeItem> SelectTreeItem(this IEnumerable<Organization> query)
    {
        return query
            .Select(o => new OrganizationTreeItem
            {
                Id = o.Id,
                Name = $"{o.Name} {o.Code}",
                Code = o.Code,
                ParentId = o.ParentId,
                HierarchyPath = o.HierarchyPath
            });
    }
}
