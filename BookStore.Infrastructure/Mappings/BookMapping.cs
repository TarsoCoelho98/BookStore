using BookStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Infrastructure.Mappings
{
    internal class BookMapping
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Book");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.Title)
                .HasColumnType("varchar(200)")
                .IsRequired();

            builder.Property(b => b.PublicationDate)
                .HasColumnType("datetime(6)")
                .IsRequired();

            builder.Property(b => b.Genre)
                .HasColumnType("varchar(100)");

            builder.Property(b => b.AuthorId)
                .HasColumnType("binary(16)")
                .IsRequired();

            builder.HasOne(b => b.Author)
                   .WithMany()
                   .HasForeignKey(b => b.AuthorId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(b => b.PublisherId)
                .HasColumnType("binary(16)")
                .IsRequired();

            builder.HasOne(b => b.Publisher)
                   .WithMany()
                   .HasForeignKey(b => b.PublisherId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(b => b.AuthorId).HasDatabaseName("IX_Book_AuthorId");
            builder.HasIndex(b => b.PublisherId).HasDatabaseName("IX_Book_PublisherId");
        }
    }
}
