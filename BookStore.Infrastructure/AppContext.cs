using BookStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookStore.Infrastructure
{
    internal class AppContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppContext).Assembly);
            
            var guidConverter = new ValueConverter<Guid, byte[]>(
                guid => guid.ToByteArray(),
                bytes => new Guid(bytes));

            var guidProperties = modelBuilder.Model
                .GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(Guid));

            foreach (var prop in guidProperties)
            {
                prop.SetColumnType("binary(16)");
                prop.SetValueConverter(guidConverter);
            }

            modelBuilder.HasCharSet("utf8mb4");
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci");

            base.OnModelCreating(modelBuilder);
        }
    }
}
