namespace Organizations.Contracts.Models;

/// <summary>
/// Базовый класс для узла в дереве
/// </summary>
public class TreeNodeDto : TreeNodeEntry<TreeNodeDto>
{
}

/// <summary>
/// Базовый класс для узла в дереве
/// </summary>
public class TreeNodeEntry<TNode> : TreeNodeEntry<TNode, Guid> where TNode : TreeNodeEntry<TNode>
{
}

/// <summary>
/// Базовый класс для узла в дереве с  идентификатором типа TKey
/// </summary>
public class TreeNodeEntry<TNode, TKey> : ClassifierDto<TKey> where TKey : struct where TNode : TreeNodeEntry<TNode, TKey>
{
    public TKey? ParentId { get; set; }

    public ICollection<TNode>? Children { get; set; }

    public TreeNodeEntry(TKey id, string name, TKey? parentId = null)
    {
        Id = id;
        Name = name;
        ParentId = parentId;
    }

    public TreeNodeEntry() { }
}