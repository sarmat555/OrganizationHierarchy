using Microsoft.EntityFrameworkCore;
using Organizations.Application.Context;
using Organizations.Contracts.Models.Abstractions;
using Organizations.Contracts.Services.Abstractions;

namespace Organizations.Application.Services.Abstractions;

public class ClassifierBaseService<TEntity, TDto> : IClassifierBaseService<TEntity, TDto>
    where TEntity : class, IClassifierEntry, new()
    where TDto : class, IClassifierDto<Guid>, new()
{

    private readonly ApplicationContext _context;

    public ClassifierBaseService(ApplicationContext context)
    {
        _context = context;
    }

    public virtual async Task<TDto[]> GetArrayAsync()
    {
        var query = _context.Set<TEntity>()
            .Where(x => !x.DeletedDate.HasValue);

        //тут должна быть фильтрация и постраничная паггинация

        var item = await query.ToListAsync();
        var result = item.Select(x => MapToDto(new TDto(), x)).ToArray();
        return result;
    }

    public virtual async Task<Guid> SaveAsync(TDto model)
    {
        TEntity entity;

        if (model.Id == Guid.Empty)//если с фронта модель пришла с нулевым идентификатором,
        {                          //то создаем новую запись(предполагается, что первичный ключ создается на уровне БД)
            entity = new TEntity();
            await _context.Set<TEntity>().AddAsync(entity);
        }
        else
        {
            entity = await _context.Set<TEntity>()
                .SingleAsync(x => x.Id == model.Id);//если в моделе есть идентификатор, то ищем уже существующую запись
        }

        MapToEntity(entity, model);

        await _context.SaveChangesAsync();
        return entity.Id;
    }

    public virtual async Task DeletedAsync(Guid id)
    {
        var entity = await _context.Set<TEntity>()
            .SingleAsync(x => x.Id == id);

        entity.DeletedDate = DateTime.UtcNow;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Собираем из ДТО объект БД
    /// </summary>
    /// <param name="dto"></param>
    /// <param name="entity"></param>
    public virtual void MapToEntity(TEntity entity, TDto dto)
    {
        entity.Name = dto.Name;
        entity.Code = dto.Code!.Value;
    }

    /// <summary>
    /// Собираем из объекта БД объект ДТО
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="dto"></param>
    public virtual TDto MapToDto(TDto dto, TEntity entity)
    {
        dto.Id = entity.Id;
        dto.Name = entity.Name;
        dto.Code = entity.Code;

        return dto;
    }
}
