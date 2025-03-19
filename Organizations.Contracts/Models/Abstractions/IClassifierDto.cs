namespace Organizations.Contracts.Models.Abstractions;

/// <summary>
/// Базовый интерфейс для моделей ДТО справочников
/// </summary>
public interface IClassifierDto<TKey> : IEntry<TKey>
    where TKey : struct
{
    public int? Code { get; set; }

    public string Name { get; set; }
}
