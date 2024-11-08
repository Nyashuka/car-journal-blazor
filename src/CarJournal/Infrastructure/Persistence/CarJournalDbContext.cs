using CarJournal.Domain;
using CarJournal.Infrastructure.Persistence.BodyTypes;
using CarJournal.Infrastructure.Persistence.Cars;
using CarJournal.Infrastructure.Persistence.Engines;
using CarJournal.Infrastructure.Persistence.FuelTypes;
using CarJournal.Infrastructure.Persistence.Gearboxes;
using CarJournal.Infrastructure.Persistence.MileageRecords;
using CarJournal.Infrastructure.Persistence.Roles;
using CarJournal.Infrastructure.Persistence.ServiceCategories;
using CarJournal.Infrastructure.Persistence.Trackings;
using CarJournal.Infrastructure.Persistence.UserCars;
using CarJournal.Infrastructure.Persistence.Vendors;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

public class CarJournalDbContext : DbContext
{
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Vendor> Vendors { get; set; }
    public DbSet<Engine> Engines { get; set; }
    public DbSet<Gearbox> Gearboxes { get; set; }
    public DbSet<FuelType> FuelTypes { get; set; }
    public DbSet<BodyType> BodyTypes { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<UserCar> UserCars { get; set; }
    public DbSet<MileageRecord> MileageRecords { get; set; }
    public DbSet<ServiceCategory> ServiceCategories { get; set; }
    public DbSet<ServiceRecord> ServiceRecords { get; set; }
    public DbSet<Tracking> Trackings { get; set; }

    public CarJournalDbContext(DbContextOptions<CarJournalDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UsersConfigurations());
        modelBuilder.ApplyConfiguration(new RolesConfiguration());
        modelBuilder.ApplyConfiguration(new VendorConfigurations());
        modelBuilder.ApplyConfiguration(new EngineConfigurations());
        modelBuilder.ApplyConfiguration(new GearboxConfigurations());
        modelBuilder.ApplyConfiguration(new FuelTypeConfigurations());
        modelBuilder.ApplyConfiguration(new BodyTypeConfigurations());
        modelBuilder.ApplyConfiguration(new CarConfigurations());
        modelBuilder.ApplyConfiguration(new UserCarsConfiguration());
        modelBuilder.ApplyConfiguration(new MileageConfiguration());
        modelBuilder.ApplyConfiguration(new ServiceCategoryConfiguration());
        modelBuilder.ApplyConfiguration(new TrackingConfiguration());

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var property in entityType.GetProperties())
            {
                if (property.ClrType == typeof(DateTime) || property.ClrType == typeof(DateTime?))
                {
                    property.SetValueConverter(new ValueConverter<DateTime, DateTime>(
                        v => v.ToUniversalTime(),
                        v => DateTime.SpecifyKind(v, DateTimeKind.Utc)
                    ));
                }
            }
        }

        CreateDefaultRoles(modelBuilder);
        CreateAdminUser(modelBuilder);
        CreateFuelTypes(modelBuilder);
    }

    private void CreateDefaultRoles(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>()
            .HasData(RolesStorage.User, RolesStorage.Admin);
    }

    private void CreateFuelTypes(ModelBuilder modelBuilder)
    {
        // modelBuilder.Entity<FuelType>()
        //     .HasData(FuelTypeCollection.FuelTypes.Values);
    }

    private void CreateAdminUser(ModelBuilder modelBuilder)
    {
        PasswordHasher.CreatePasswordHash("admin", out var passwordHash, out var passwordSalt);

        modelBuilder.Entity<User>()
            .HasData(
                new User(-1, "admin@gmail.com", passwordHash, passwordSalt, RolesStorage.Admin.Id)
            );
    }
}