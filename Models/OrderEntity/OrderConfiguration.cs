using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PublishingHouse.Models.OrderEntity
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .HasOne(p => p.User)
                .WithMany(p => p.Orders)
                .HasForeignKey(p => p.UserId);

            builder
                .HasMany(p => p.PrintedEditions)
                .WithMany(p => p.Orders);

            builder
                .Property(p => p.Status)
                .HasMaxLength(20);

            builder
                .Property(p => p.TotalPrice)
                .HasColumnType("money");
        }
    }
}
