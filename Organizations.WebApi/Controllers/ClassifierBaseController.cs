using Microsoft.AspNetCore.Mvc;
using Organizations.Contracts.Models.Abstractions;
using Organizations.Contracts.Services.Abstractions;

namespace Organizations.WebApi.Controllers
{
    public abstract class ClassifierBaseController<TEntity, TDto>(IClassifierBaseService<TEntity, TDto> service) : ControllerBase
        where TEntity : IClassifierEntry
        where TDto : IClassifierDto<Guid>
    {

        /// <summary>
        /// Получаем список
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public virtual async Task<IActionResult> GetArray()
        {
            var data = await service.GetArrayAsync();
            return Ok(data);
        }

        /// <summary>
        /// Сохранение записи в справочник
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual async Task<IActionResult> Save(TDto model)
        {
            var data = await service.SaveAsync(model);
            return Ok(data);
        }

        /// <summary>
        /// Удаление записи из справочника
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public virtual async Task<IActionResult> Delete(Guid id)
        {
            await service.DeletedAsync(id);
            return Ok();
        }
    }
}
