using CarJournal.Domain;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarJournal.Infrastructure.Persistence.Vendors;

public class VendorConfigurations : IEntityTypeConfiguration<Vendor>
{
    public void Configure(EntityTypeBuilder<Vendor> builder)
    {
        // Налаштування таблиці
        builder.ToTable("Vendors"); // Ім'я таблиці в базі даних

        // Налаштування первинного ключа
        builder.HasKey(v => v.Id);

        // Налаштування властивості Id
        builder.Property(v => v.Id)
            .ValueGeneratedNever(); // Вказує, що Id не буде генеруватися автоматично

        // Налаштування властивості Name
        builder.Property(v => v.Name)
            .IsRequired()  // Властивість Name є обов'язковою
            .HasMaxLength(256); // Максимальна довжина для властивості Name

        builder.HasIndex(v => v.Name).IsUnique();
    }
}
