using Fluent_Api.Domaiin.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Faluent_Api.Application.Configuration
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(a => a.AuthorId);

            builder.Property(a => a.AuthorName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(a => a.DateOfBirth)
                .IsRequired();

            builder.Property(a => a.Country)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasMany(a => a.Books)
                .WithOne(b => b.Author)
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
