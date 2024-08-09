namespace CarJournal.Services.Authentication;

public record AuthenticationResult(
    int Id,
    string Email,
    string Token
);