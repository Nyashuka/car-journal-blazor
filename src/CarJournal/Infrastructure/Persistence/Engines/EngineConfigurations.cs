using CarJournal.Domain;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarJournal.Infrastructure.Persistence.Engines;

public class EngineConfigurations : IEntityTypeConfiguration<Engine>
{
    public void Configure(EntityTypeBuilder<Engine> builder)
    {
        builder.ToTable("Engines");

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
