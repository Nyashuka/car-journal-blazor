using CarJournal.Domain;

using Microsoft.EntityFrameworkCore;

public class CarJournalDbContext : DbContext
{
    public DbSet<User> Users { get; set; } 

    public CarJournalDbContext(DbContextOptions<CarJournalDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}