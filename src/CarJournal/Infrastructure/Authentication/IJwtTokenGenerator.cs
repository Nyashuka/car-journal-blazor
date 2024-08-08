namespace CarJournal.Infrastructure.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(Guid id);
}