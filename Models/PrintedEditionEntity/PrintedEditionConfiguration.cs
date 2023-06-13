using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PublishingHouse.Models.PrintedEditionEntity
{
    public class PrintedEditionConfiguration : IEntityTypeConfiguration<PrintedEdition>
    {
        public void Configure(EntityTypeBuilder<PrintedEdition> builder)
        {
            builder
                .Property(p => p.Title)
                .HasMaxLength(200);

            builder
                .Property(p => p.Description)
                .IsRequired(false)
                .HasMaxLength(1000);

            builder
                .Property(p => p.Language)
                .HasMaxLength(100);

            builder
                .Property(p => p.Price)
                .HasColumnType("money");

            builder
                .Property(p => p.ReleaseDate);

            builder
                .Property(p => p.Updated);

            builder
                .Property(p => p.IsAvailable)
                .HasDefaultValue(true);

            builder
                .Property(p => p.Author)
                .HasMaxLength(100);

            builder
                .Property(p => p.Genre)
                .HasMaxLength(100);

            builder
                .Property(p => p.Cover)
                .HasColumnType("image")
                .IsRequired(false);

            builder
                .HasMany(p => p.Orders)
                .WithMany(p => p.PrintedEditions);
        }
    }
}
