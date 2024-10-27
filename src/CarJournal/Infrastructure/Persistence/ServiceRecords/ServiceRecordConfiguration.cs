using CarJournal.Domain;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarJournal.Infrastructure.Persistence.ServiceRecords;

public class ServiceRecordConfiguration : IEntityTypeConfiguration<ServiceRecord>
{
    public void Configure(EntityTypeBuilder<ServiceRecord> builder)
    {
        builder.HasKey(sr => sr.Id);

        builder.Property(sr => sr.Id)
            .ValueGeneratedOnAdd();

        builder.Property(sr => sr.Title)
            .IsRequired();

        builder.Property(sr => sr.UserCarId)
            .IsRequired();

        builder.Property(sr => sr.Mileage)
            .IsRequired();

        builder.Property(sr => sr.Price)
            .IsRequired();

        builder.Property(sr => sr.ServiceCategoryId)
            .IsRequired();

        builder.Property(sr => sr.Description)
            .IsRequired(false);

        builder.Property(sr => sr.DateOfService)
            .IsRequired()
            .HasConversion(
                v => v.ToUniversalTime(),
                v => DateTime.SpecifyKind(v, DateTimeKind.Utc)
            );

        builder.HasOne(sr => sr.ServiceCategory)
            .WithMany()
            .HasForeignKey(sr => sr.ServiceCategoryId);

        builder.HasOne(sr => sr.UserCar)
            .WithMany()
            .HasForeignKey(sr => sr.UserCarId);
    }
}
