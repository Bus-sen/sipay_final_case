using Microsoft.EntityFrameworkCore;

namespace Data;

public class SipayDbContext : DbContext
{
    public SipayDbContext(DbContextOptions<SipayDbContext> options) : base(options)
    {

    }

    public DbSet<Householder> Householders { get; set; }
    public DbSet<HouseDetail> HouseDetails { get; set; }
    public DbSet<Bill> Bills { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new HouseholderConfiguration());
        modelBuilder.ApplyConfiguration(new HouseDetailConfiguration());
        modelBuilder.ApplyConfiguration(new BillConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }
}
