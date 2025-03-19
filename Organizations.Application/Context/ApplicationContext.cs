using Microsoft.EntityFrameworkCore;
using Organizations.Domain.Organizations;

namespace Organizations.Application.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Organization> Organizations { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Зададим по умолчанию одну организацию
            modelBuilder.Entity<Organization>().HasData(
                    new Organization { Id = Guid.Parse("badaf1b5-587b-48ed-97e1-49a19c9eaf4d"), Name = "Компания", Code = 1, HierarchyPath = "/1" }
            );
        }
    }
}
