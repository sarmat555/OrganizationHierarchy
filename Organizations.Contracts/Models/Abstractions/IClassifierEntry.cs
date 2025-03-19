namespace Organizations.Contracts.Models.Abstractions;

/// <summary>
/// Базовый интерфейс для моделей БД справочников
/// </summary>
public interface IClassifierEntry : IEntry<Guid>
{
    public int Code { get; set; }

    public string Name { get; set; }

    public DateTimeOffset? DeletedDate { get; set; }
}
