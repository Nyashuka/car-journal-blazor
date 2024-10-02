
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

        builder.HasOne(u => u.Role)
            .WithMany() // Не вказуємо колекцію ролей в Role
            .HasForeignKey(u => u.RoleId) // Вказуємо зовнішній ключ
            .OnDelete(DeleteBehavior.Restrict); // Не дозволяє видаляти ролі, якщо є користувачі

    }
}