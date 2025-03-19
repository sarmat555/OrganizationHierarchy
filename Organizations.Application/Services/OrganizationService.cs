using Microsoft.EntityFrameworkCore;
using Organizations.Application.Context;
using Organizations.Application.Services.Abstractions;
using Organizations.Contracts.Mappers;
using Organizations.Contracts.Models;
using Organizations.Contracts.Services;
using Organizations.Domain.Organizations;

namespace Organizations.Application.Services
{
    public class OrganizationService : ClassifierBaseService<Organization, OrganizationTreeItem>, IOrganizationService<Organization, OrganizationTreeItem>
    {
        private readonly ApplicationContext _context;
        public OrganizationService(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<Guid> SaveAsync(OrganizationTreeItem model)
        {
            var parentInfoQuery = _context.Organizations.AsQueryable();
            
            if (model.ParentId.HasValue)
                parentInfoQuery = parentInfoQuery.Where(x => x.Id == model.ParentId);

            //беру только те данные, которые мне необходимы, так как сущность может быть большая и нет смысла ее всю загружать
            var parentInfo = await parentInfoQuery
                .Select(x => new
                {           //если в модели нет родительского элемента, то считаем, что создается корневая организация
                    Code = model.ParentId.HasValue ? 
                                x.Childs.Any() ? x.Childs.OrderByDescending(x => x.Code).First().Code : 0
                            : x.Code,
                    x.HierarchyPath
                })
            .SingleAsync();

            model.Code = parentInfo.Code + 1;
            model.HierarchyPath = model.ParentId.HasValue ? $"{parentInfo.HierarchyPath}/{model.Code}" : $"/{parentInfo.Code}";

            return await base.SaveAsync(model);
        }

        public override void MapToEntity(Organization entity, OrganizationTreeItem dto)
        {
            base.MapToEntity(entity, dto);
            entity.HierarchyPath = dto.HierarchyPath!;
            entity.ParentId = dto.ParentId;
        }

        /// <summary>
        /// Получить иерархический список 
        /// </summary>
        /// <returns></returns>
        public async Task<OrganizationTreeItem[]> GetTreeAsync()
        {
            var rootItem = await _context.Organizations
                .Where(o => !o.DeletedDate.HasValue)
                .Where(o => o.HierarchyPath == "/1")
                .SelectTreeItem()
                .FirstOrDefaultAsync(o => o.ParentId == null);

            if (rootItem == null)
                throw new InvalidOperationException("Не найдена корневая организация");
            rootItem.HierarchyPath ??= "/";

            var entityQuery = _context.Organizations
                .Where(o => !o.DeletedDate.HasValue)
                .Where(o => o.ParentId.HasValue);

            var data = await entityQuery
                .ToListAsync();

            var globalSet = new HashSet<string>();
            rootItem = CalculateTree(data.SelectTreeItem().ToList(), rootItem, globalSet);
            rootItem.Children ??= new List<OrganizationTreeItem>();

            return new[] { rootItem };
        }

        private OrganizationTreeItem CalculateTree(List<OrganizationTreeItem> allitems,
    OrganizationTreeItem currentItem, HashSet<string> set)
        {
            var descendants = allitems
                .Where(o => !string.IsNullOrWhiteSpace(o.HierarchyPath))
                .Where(o => o.HierarchyPath.StartsWith(currentItem.HierarchyPath) && o.Id != currentItem.Id)
                .ToList();

            if (!descendants.Any())
                return currentItem;

            var ordered = descendants.OrderBy(o => o.HierarchyPath.Split("/").Length).ToList();
            foreach (var organizationTreeItem in ordered)
            {
                var result = CalculateTree(ordered, organizationTreeItem, set);

                if (set.Contains(result.HierarchyPath))
                    continue;

                set.Add(result.HierarchyPath);
                currentItem.Children ??= new List<OrganizationTreeItem>();
                currentItem.Children.Add(result);
            }

            return currentItem;
        }
    }
}
