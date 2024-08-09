
using CarJournal.Domain;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UsersConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        // Назва таблиці
        builder.ToTable("Users");

        // Первинний ключ
        builder.HasKey(u => u.Id);

        // Властивість Id
        builder.Property(u => u.Id)
            .ValueGeneratedOnAdd(); // Генерація Id під час додавання запису

        // Властивість Email
        builder.Property(u => u.Email)
            .IsRequired()           // Email є обов'язковим
            .HasMaxLength(255);      // Максимальна довжина Email

        // Властивість RoleId
        builder.Property(u => u.RoleId)
            .IsRequired();           // RoleId є обов'язковим

        // Властивість PasswordHash
        builder.Property(u => u.PasswordHash)
            .IsRequired();           // PasswordHash є обов'язковим

        // Властивість PasswordSalt
        builder.Property(u => u.PasswordSalt)
            .IsRequired();           // PasswordSalt є обов'язковим

    }
}