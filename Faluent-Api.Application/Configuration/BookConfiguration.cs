using Fluent_Api.Domaiin.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Faluent_Api.Application.Configuration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.BookId);

            builder.Property(b => b.BookName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(b => b.AuthorId)
                .IsRequired();

            builder.Property(b => b.Publisher)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(b => b.PublicationYear)
                .IsRequired();

            builder.Property(b => b.ISBN)
                .IsRequired()
                .HasMaxLength(20);


            builder.HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(b => b.BookCategories)
                .WithOne(bc => bc.Book)
                .HasForeignKey(bc => bc.BookId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
