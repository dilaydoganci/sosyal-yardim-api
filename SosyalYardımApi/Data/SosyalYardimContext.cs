using Microsoft.EntityFrameworkCore;
using SosyalYardimApi.Models;

namespace SosyalYardimApi.Data
{
    public class SosyalYardimContext : DbContext
    {
        public SosyalYardimContext(DbContextOptions<SosyalYardimContext> options)
            : base(options)
        {
        }

        public DbSet<SosyalYardim> SosyalYardimlar { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SosyalYardim>(entity =>
            {
                entity.Property(e => e.OdenecekTtr).HasColumnType("decimal(18, 2)");
            });
        }
    }
}
