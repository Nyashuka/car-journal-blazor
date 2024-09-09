using CarJournal.Domain;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarJournal.Infrastructure.Persistence.Gearboxes;

public class GearboxConfigurations : IEntityTypeConfiguration<Gearbox>
{
    public void Configure(EntityTypeBuilder<Gearbox> builder)
    {
        builder.ToTable("Gearboxes");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd();

        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(256);
    }
}