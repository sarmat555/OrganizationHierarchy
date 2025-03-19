using Organizations.Contracts.Models.Abstractions;

namespace Organizations.Contracts.Models;

public class OrganizationTreeItem : TreeNodeEntry<OrganizationTreeItem, Guid>, IClassifierDto<Guid>
{
    public string? HierarchyPath { get; set; }

    public int? Code { get; set; }
}