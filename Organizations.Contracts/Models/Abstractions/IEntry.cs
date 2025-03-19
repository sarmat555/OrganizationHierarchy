namespace Organizations.Contracts.Models.Abstractions
{
    /// <summary>
    /// Базовый интерфейс моделей с идентификатором типа TKey
    /// </summary>
    public interface IEntry<TKey>
    {
        TKey Id { get; set; }
    }
}
