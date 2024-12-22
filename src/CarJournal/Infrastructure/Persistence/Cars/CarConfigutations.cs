using CarJournal.Domain;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarJournal.Infrastructure.Persistence.Cars;

public class CarConfigurations : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .ValueGeneratedOnAdd();

        builder.Property(c => c.Model)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(c => c.Series)
            .HasMaxLength(50);

        builder.Property(c => c.Year)
            .IsRequired();

        builder.HasOne(c => c.Vendor)
            .WithMany()
            .HasForeignKey(c => c.VendorId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(c => c.BodyType)
            .WithMany()
            .HasForeignKey(c => c.BodyTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(c => c.Engine)
            .WithMany()
            .HasForeignKey(c => c.EngineId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(c => c.Gearbox)
            .WithMany()
            .HasForeignKey(c => c.GearboxId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(c => c.FuelType)
            .WithMany()
            .HasForeignKey(c => c.FuelTypeId)
            .OnDelete(DeleteBehavior.Restrict);


        builder.Property(c => c.DocumentationUrl)
            .IsRequired(false);
    }
}