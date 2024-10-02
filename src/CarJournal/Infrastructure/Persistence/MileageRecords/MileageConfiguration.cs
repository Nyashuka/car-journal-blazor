using CarJournal.Domain;

using Microsoft.EntityFrameworkCore;

namespace CarJournal.Infrastructure.Persistence.MileageRecords;

public class MileageConfiguration : IEntityTypeConfiguration<MileageRecord>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<MileageRecord> builder)
    {
        builder.HasKey(mr => mr.Id);

        builder.Property(mr => mr.Mileage)
            .IsRequired();

        builder.Property(mr => mr.IsAutomatic)
            .IsRequired();

        builder.Property(mr => mr.UserCarId)
            .IsRequired();

        builder.HasOne(mr => mr.UserCar)
            .WithMany()
            .HasForeignKey(mr => mr.UserCarId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(mr => mr.UpdatedAt)
            .IsRequired();
    }
}
