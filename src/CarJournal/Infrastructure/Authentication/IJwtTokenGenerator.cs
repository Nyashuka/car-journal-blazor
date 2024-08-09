namespace CarJournal.Infrastructure.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(int id);
}