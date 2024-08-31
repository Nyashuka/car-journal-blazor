using CarJournal.Domain;
using CarJournal.Infrastructure.Persistence.Roles;
using CarJournal.Infrastructure.Persistence.Vendors;

using Microsoft.EntityFrameworkCore;

public class CarJournalDbContext : DbContext
{
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Vendor> Vendors { get; set; }

    public CarJournalDbContext(DbContextOptions<CarJournalDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UsersConfigurations());
        modelBuilder.ApplyConfiguration(new RolesConfiguration());
        modelBuilder.ApplyConfiguration(new VendorConfigurations());

        CreateDefaultRoles(modelBuilder);
        CreateAdminUser(modelBuilder);
    }

    private void CreateDefaultRoles(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>()
        .HasData(RolesStorage.User, RolesStorage.Admin);
    }

    private void CreateAdminUser(ModelBuilder modelBuilder)
    {
        PasswordHasher.CreatePasswordHash("admin", out var passwordHash, out var passwordSalt);

        modelBuilder.Entity<User>()
        .HasData(
            new User(-1, "admin", passwordHash, passwordSalt, RolesStorage.Admin.Id)
        );
    }
}