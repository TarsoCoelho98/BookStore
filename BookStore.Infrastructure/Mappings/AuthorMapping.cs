using BookStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Infrastructure.Mappings
{
    internal class AuthorMapping : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Author");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Name)
                .HasColumnType("varchar(200)")
                .IsRequired();

            builder.Property(a => a.Birthdate)
                .HasColumnType("datetime(6)")
                .IsRequired();

            builder.Property(a => a.Country)
                .HasColumnType("varchar(100)")
                .IsRequired();
        }
    }
}
