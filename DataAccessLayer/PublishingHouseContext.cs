using PublishingHouse.Models.OrderEntity;
using PublishingHouse.Models.UserEntity;
using Microsoft.EntityFrameworkCore;
using PublishingHouse.Models.CategoryEntity;
using PublishingHouse.Models.PrintedEditionEntity;
using PublishingHouse.Constats;

namespace PublishingHouse.DataAccessLayer
{
    public class PublishingHouseContext : DbContext
    {
        public DbSet<PrintedEdition> PrintedEdition { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Category> Category { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(PathConstants.DbConnectionPath);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PrintedEditionConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());

            modelBuilder.Seed();

            base.OnModelCreating(modelBuilder);
        }
    }
}
