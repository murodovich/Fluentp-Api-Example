using Fluent_Api.Domaiin.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.RegularExpressions;

namespace Faluent_Api.Application.Configuration
{
    public class UserTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.UserId);

            builder.Property(x => x.LastName)
                .HasMaxLength(30);

            builder.Property(x => x.FirstName)
                .HasMaxLength(30);


            var emailRegex = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
            builder.Property(x => x.Email)
           .IsRequired()
           .HasMaxLength(50)
           .IsUnicode(false)
           .HasConversion(
               v => v,
               v => emailRegex.IsMatch(v) ? v : "Invalid email format");

            builder.Property(x => x.UserName)
                .HasMaxLength(30);

            var passwordRegex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$");

            builder.Property(x => x.PasswordHash)
                .HasMaxLength(8)
                .IsUnicode(true)
                .HasConversion(
                    x => x,
                    x => passwordRegex.IsMatch(x) ? x : "Invalid password format");




        }
        
            


            

        
    }
}
