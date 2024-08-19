using CarJournal.Domain;
using CarJournal.Infrastructure.Persistence.Roles;

using Microsoft.EntityFrameworkCore;

public class CarJournalDbContext : DbContext
{
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }

    public CarJournalDbContext(DbContextOptions<CarJournalDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UsersConfigurations());
        modelBuilder.ApplyConfiguration(new RolesConfiguration());

        CreateDefaultRoles(modelBuilder);
    }

    private void CreateDefaultRoles(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>()
        .HasData(RolesStorage.User, RolesStorage.Admin);
    }
}