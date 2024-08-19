namespace CarJournal.Infrastructure.Persistence.Roles;

public class RoleRepository : IRoleRepository
{
    private readonly CarJournalDbContext _dbContext;

    public RoleRepository(CarJournalDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Role? GetById(int id)
    {
        return _dbContext.Roles.SingleOrDefault(r => r.Id == id);
    }
}