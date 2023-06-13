using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PublishingHouse.Models.UserEntity
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .Property(p => p.FirstName)
                .HasMaxLength(800);

            builder
                .Property(p => p.LastName)
                .HasMaxLength(800);

            builder
               .Property(p => p.IsBlacklisted)
               .HasDefaultValue(false);

            builder
               .Property(p => p.Login)
               .HasMaxLength(50);

            builder
              .Property(p => p.Role)
              .HasMaxLength(20);

            builder
               .Property(p => p.PasswordHash)
               .HasMaxLength(60);

            builder
                .HasMany(p => p.Orders)
                .WithOne(p => p.User);
        }
    }
}
