using CarJournal.Domain;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarJournal.Infrastructure.Persistence.Cars;

public class CarConfigurations : IEntityTypeConfiguration<Car>
{
//     public void Configure(EntityTypeBuilder<Car> builder)
//    {
//         // Вказуємо, що Id є ключем
//         builder.HasKey(c => c.Id);

//         // Вказуємо, що Model є обов'язковим полем
//         builder.Property(c => c.Model)
//             .IsRequired()
//             .HasMaxLength(100);  // Максимальна довжина для моделі

//         // Вказуємо, що Series є необов'язковим полем
//         builder.Property(c => c.Series)
//             .HasMaxLength(50);  // Максимальна довжина для серії

//         // Поле Year є обов'язковим
//         builder.Property(c => c.Year)
//             .IsRequired();

//         // Налаштування відношення 1 до N між Car та Vendor
//         builder.HasOne(c => c.Vendor)
//             .WithMany(v => v.Cars)  // Вказуємо, що у постачальника може бути багато машин
//             .HasForeignKey(c => c.VendorId)
//             .OnDelete(DeleteBehavior.Cascade);  // Видалення постачальника видалить усі його машини

//         // Налаштування зв'язку з BodyType
//         builder.HasOne(c => c.BodyType)
//             .WithMany(bt => bt.Cars)
//             .HasForeignKey(c => c.BodyTypeId)
//             .OnDelete(DeleteBehavior.Restrict);

//         // Налаштування зв'язку з Engine
//         builder.HasOne(c => c.Engine)
//             .WithMany(e => e.Cars)
//             .HasForeignKey(c => c.EngineId)
//             .OnDelete(DeleteBehavior.Restrict);

//         // Налаштування зв'язку з Gearbox
//         builder.HasOne(c => c.Gearbox)
//             .WithMany(g => g.Cars)
//             .HasForeignKey(c => c.GearboxId)
//             .OnDelete(DeleteBehavior.Restrict);

//         // Налаштування зв'язку з FuelType
//         builder.HasOne(c => c.FuelType)
//             .WithMany(f => f.Cars)
//             .HasForeignKey(c => c.FuelTypeId)
//             .OnDelete(DeleteBehavior.Restrict);

//         // Створення індекса на поле Model
//         builder.HasIndex(c => c.Model)
//             .IsUnique();  // Унікальний індекс для моделі
//     }

    public void Configure(EntityTypeBuilder<Car> builder)
    {
        // Вказуємо, що Id є ключем
        builder.HasKey(c => c.Id);

        // Вказуємо, що Model є обов'язковим полем
        builder.Property(c => c.Model)
            .IsRequired()
            .HasMaxLength(100);  // Максимальна довжина для моделі

        // Вказуємо, що Series є необов'язковим полем
        builder.Property(c => c.Series)
            .HasMaxLength(50);  // Максимальна довжина для серії

        // Поле Year є обов'язковим
        builder.Property(c => c.Year)
            .IsRequired();

        // Налаштування відношення багато до одного між Car та Vendor
        builder.HasOne(c => c.Vendor)
            .WithMany()
            .HasForeignKey(c => c.VendorId)
            .OnDelete(DeleteBehavior.Cascade);  // Видалення постачальника видалить усі його машини

        // Налаштування зв'язку з BodyType
        builder.HasOne(c => c.BodyType)
            .WithMany()
            .HasForeignKey(c => c.BodyTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        // Налаштування зв'язку з Engine
        builder.HasOne(c => c.Engine)
            .WithMany()
            .HasForeignKey(c => c.EngineId)
            .OnDelete(DeleteBehavior.Restrict);

        // Налаштування зв'язку з Gearbox
        builder.HasOne(c => c.Gearbox)
            .WithMany()
            .HasForeignKey(c => c.GearboxId)
            .OnDelete(DeleteBehavior.Restrict);

        // Налаштування зв'язку з FuelType
        builder.HasOne(c => c.FuelType)
            .WithMany()
            .HasForeignKey(c => c.FuelTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        // Створення індекса на поле Model
        builder.HasIndex(c => c.Model)
            .IsUnique();
    }

}