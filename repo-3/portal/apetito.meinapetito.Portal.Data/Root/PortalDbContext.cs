using apetito.meinapetito.Portal.Data.Root.MainCustomerAdmins.CustomerNumbers;
using apetito.meinapetito.Portal.Data.Root.MainCustomerAdmins.CustomerNumbers.Sortiments;
using apetito.meinapetito.Portal.Data.Root.MainCustomerAdmins.PortalUsers;
using apetito.meinapetito.Portal.Data.Root.Users;
using Microsoft.EntityFrameworkCore;

namespace apetito.meinapetito.Portal.Data.Root;

public class PortalDbContext : DbContext
{
    public PortalDbContext(DbContextOptions<PortalDbContext> options) : base(options)
    {
    }
    public DbSet<PortalUserData> PortalUsers => Set<PortalUserData>();
    public DbSet<PortalUserCustomerNumbersData> PortalUserCustomerNumbers => Set<PortalUserCustomerNumbersData>();
    public DbSet<PortalUserCustomerNumbersEntryData> PortalUserCustomerNumbersEntries => Set<PortalUserCustomerNumbersEntryData>();
    
    public DbSet<PortalUserCustomerNumberEntrySortimentData> PortalUserCustomerNumberEntrySortiments => Set<PortalUserCustomerNumberEntrySortimentData>();
    public DbSet<PortalUserCustomerNumberEntrySortimentEntryData> PortalUserCustomerNumberEntrySortimentsEntries => Set<PortalUserCustomerNumberEntrySortimentEntryData>();
    
    public DbSet<PortalUserFilter?> PortalUserFilters => Set<PortalUserFilter>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CS_AS");

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IApetitoMeinApetitoPortalDataMarker).Assembly);
        
        modelBuilder.Entity<PortalUserCustomerNumbersData>().HasKey(a => a.PortalUserCustomerNumbersId);
        modelBuilder.Entity<PortalUserCustomerNumbersEntryData>().HasKey(a => a.PortalUserCustomerNumbersEntryId);
        
        modelBuilder.Entity<PortalUserData>().HasKey(a => a.PortalUserId);
        
        modelBuilder.Entity<PortalUserCustomerNumbersEntryData>()
            .HasOne<PortalUserCustomerNumbersData>()
            .WithMany(g => g.CustomerNumbers)
            .HasForeignKey(s => s.PortalUserCustomerNumbersId);
        
        modelBuilder.Entity<PortalUserCustomerNumberEntrySortimentData>().HasKey(a => a.PortalUserCustomerNumbersEntrySortimentId);
        modelBuilder.Entity<PortalUserCustomerNumberEntrySortimentEntryData>().HasKey(a => a.PortalUserCustomerNumbersEntrySortimentEntryId);
        
        modelBuilder.Entity<PortalUserCustomerNumberEntrySortimentEntryData>()
            .HasOne<PortalUserCustomerNumberEntrySortimentData>()
            .WithMany(g => g.Sortiments)
            .HasForeignKey(s => s.PortalUserCustomerNumbersEntrySortimentId);
    }
}