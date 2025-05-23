using aff.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace aff.Data
{
    public class AffContext: DbContext
    {
    public DbSet<UserPortfolio> Affs { get; set; }
    public DbSet<OrderResult> Orders { get; set; }

    public AffContext(DbContextOptions<AffContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserPortfolio>().ToTable("Affs");
            modelBuilder.Entity<UserPortfolio>().HasKey(x => x.PortfolioId);
            modelBuilder.Entity<OrderResult>().ToTable("Orders");
            modelBuilder.Entity<OrderResult>().HasKey(x => x.OrderId);
        }
    }

}
