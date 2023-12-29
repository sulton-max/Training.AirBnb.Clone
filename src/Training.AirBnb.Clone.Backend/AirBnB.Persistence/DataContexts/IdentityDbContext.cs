using AirBnB.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AirBnB.Persistence.DataContexts;

public class IdentityDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Role> Roles => Set<Role>();

    public DbSet<UserInfoVerificationCode> UserInfoVerificationCodes => Set<UserInfoVerificationCode>();
    
    public DbSet<Listing> Listings => Set<Listing>();

    public DbSet<StorageFile> StorageFiles => Set<StorageFile>();

    public DbSet<UserSettings> UserSettings => Set<UserSettings>();

    public DbSet<ListingCategory> ListingCategories => Set<ListingCategory>();

    public IdentityDbContext(DbContextOptions<IdentityDbContext> dbContextOptions) : base(dbContextOptions)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("identity");
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IdentityDbContext).Assembly);
    }
}