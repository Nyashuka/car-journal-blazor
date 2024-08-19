namespace CarJournal.Infrastructure.Persistence.Roles;

public interface IRoleRepository
{
    Role? GetById(int id);
}