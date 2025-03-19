using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Organizations.Domain.Organizations
{
    /// <summary>
    /// Модель для организации
    /// </summary>
    public sealed class Organization : ClassifierEntry
    {
        public Organization() { }

        /// <summary>
        /// Идентификатор вышестоящей организации
        /// </summary>
        public Guid? ParentId { get; set; }

        /// <summary>
        /// Вышестоящая организация
        /// </summary>
        public Organization? Parent { get; set; }

        public ICollection<Organization> Childs { get; set; }

        /// <summary>
        /// Иерархия организаций в виде /1/1/1 для поиска подчиненных организаций без рекурсии
        /// </summary>
        public string HierarchyPath { get; set; }

        public class Map : IEntityTypeConfiguration<Organization>
        {
            public void Configure(EntityTypeBuilder<Organization> builder)
            {
                builder.ToTable("organizations");

                builder.HasOne(x => x.Parent).WithMany().HasForeignKey(x => x.ParentId);
                builder.HasMany(x => x.Childs).WithOne(x => x.Parent).HasForeignKey(x => x.ParentId);

                builder.Property(t => t.ParentId).HasColumnName("parent_id");//в проекте по умолчанию настроены поля как snake_case, использую для демонстации
                builder.Property(t => t.HierarchyPath).HasColumnName("hierarchy_path");

                builder.MapClassifierEntry();
            }
        }
    }
}
