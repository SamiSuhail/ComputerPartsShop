using ComputerPartsShop.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ComputerPartsShop.Data
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options)
            :base(options)
        {

        }

        public DbSet<RandomAccessMemory> RandomAccessMemories { get; init; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RandomAccessMemory>()
                .HasIndex(r => r.Model)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}
