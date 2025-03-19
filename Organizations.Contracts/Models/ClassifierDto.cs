using Organizations.Contracts.Models.Abstractions;

namespace Organizations.Contracts.Models;

/// <summary>
/// Класс для обмена справочниками между фронтом и бэком
/// </summary>
public class ClassifierDto<TKey> : IClassifierDto<TKey>
    where TKey : struct
{
    public TKey Id { get; set; }

    public int? Code { get; set; }

    public string Name { get; set; }
}
