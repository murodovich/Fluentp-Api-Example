using Fluent_Api.Domaiin.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Faluent_Api.Application.Configuration
{
    public class BorrowedBookConfiguration : IEntityTypeConfiguration<BorrowedBook>
    {
        public void Configure(EntityTypeBuilder<BorrowedBook> builder)
        {
            builder.HasKey(bb => bb.TransactionId);

            builder.Property(bb => bb.BookId)
                .IsRequired();

            builder.Property(bb => bb.UserId)
                .IsRequired();

            builder.Property(bb => bb.BorrowedDate)
                .IsRequired();

            builder.Property(bb => bb.ReturnDate)
                .IsRequired();

            builder.Property(bb => bb.Status)
                .IsRequired()
                .HasMaxLength(50);


            builder.HasOne(bb => bb.Book)
                .WithMany(b => b.BorrowedBooks)
                .HasForeignKey(bb => bb.BookId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(bb => bb.User)
                .WithMany(u => u.BorrowedBooks)
                .HasForeignKey(bb => bb.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
