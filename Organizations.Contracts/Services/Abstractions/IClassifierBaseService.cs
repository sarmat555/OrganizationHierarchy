using Organizations.Contracts.Models.Abstractions;

namespace Organizations.Contracts.Services.Abstractions;

/// <summary>
/// Интерфейс базовых операций над справочником(чтение, добавление, удаление)
/// </summary>
public interface IClassifierBaseService<TEntity, TDto> 
    where TEntity : IClassifierEntry
    where TDto : IClassifierDto<Guid>
{
    /// <summary>
    /// Получаем список
    /// </summary>
    /// <returns></returns>
    public Task<TDto[]> GetArrayAsync();//по хорошему в качестве параметров должны принимать объект с фильтрацией и постраничной паггинацией

    /// <summary>
    /// Сохранение записи в справочник
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    public Task<Guid> SaveAsync(TDto model);

    /// <summary>
    /// Удаление записи из справочника
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task DeletedAsync(Guid id);
}
