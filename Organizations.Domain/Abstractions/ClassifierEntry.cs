using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Organizations.Contracts.Models.Abstractions;

namespace Organizations.Domain;

/// <summary>
/// Базовый класс моделей справочников
/// </summary>
public abstract class ClassifierEntry : IClassifierEntry
{
    public Guid Id { get; set; }

    public int Code { get; set; }

    public string Name { get; set; }

    public DateTimeOffset? DeletedDate { get; set; }
}

public static class ClassifierEntryConfiguration
{
    public static void MapClassifierEntry<TEntity>(this EntityTypeBuilder<TEntity> builder) where TEntity : ClassifierEntry
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.Code).HasColumnName("code");
        builder.Property(x => x.Name).HasColumnName("name");
        builder.Property(x => x.DeletedDate).HasColumnName("deleted_date");
    }
}
