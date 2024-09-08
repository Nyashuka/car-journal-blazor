using CarJournal.Domain;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarJournal.Infrastructure.Persistence.Engines;

public class EngineConfigurations : IEntityTypeConfiguration<Engine>
{
    public void Configure(EntityTypeBuilder<Engine> builder)
    {
        // Налаштування таблиці
        builder.ToTable("Engines"); // Ім'я таблиці в базі даних

        // Налаштування первинного ключа
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd();

        builder.Property(e => e.Model)
            .IsRequired()
            .HasMaxLength(256);

        builder.Property(e => e.EngineSize)
            .IsRequired();
    }
}
