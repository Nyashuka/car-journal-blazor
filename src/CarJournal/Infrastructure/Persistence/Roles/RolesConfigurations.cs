using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarJournal.Infrastructure.Persistence.Roles;

public class RolesConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        // Налаштування таблиці
        builder.ToTable("Roles"); // Ім'я таблиці в базі даних

        // Налаштування первинного ключа
        builder.HasKey(r => r.Id);

        // Налаштування властивості Id
        builder.Property(r => r.Id)
            .ValueGeneratedNever(); // Вказує, що Id не буде генеруватися автоматично

        // Налаштування властивості Name
        builder.Property(r => r.Name)
            .IsRequired()  // Властивість Name є обов'язковою
            .HasMaxLength(256); // Максимальна довжина для властивості Name

        builder.HasIndex(r => r.Name).IsUnique();
    }
}