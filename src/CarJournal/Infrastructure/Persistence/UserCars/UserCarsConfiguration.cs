using CarJournal.Domain;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarJournal.Infrastructure.Persistence.UserCars;

public class UserCarsConfiguration : IEntityTypeConfiguration<UserCar>
{
    public void Configure(EntityTypeBuilder<UserCar> builder)
    {
        builder.HasKey(uc => uc.Id);

        builder.Property(uc => uc.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(uc => uc.StartMileage)
            .IsRequired();

        builder.Property(uc => uc.CurrentMileage)
            .IsRequired();

        builder.Property(uc => uc.UserId)
            .IsRequired();

        builder.Property(uc => uc.CarId)
            .IsRequired(false);

        builder.Property(uc => uc.DateOfAdd)
            .IsRequired();

        builder.HasOne(uc => uc.User)
            .WithMany()
            .HasForeignKey(uc => uc.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(uc => uc.Car)
            .WithMany()
            .HasForeignKey(uc => uc.CarId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}