namespace CarJournal.Api.Authentication;

public record AuthenticationResponse(
    int Id,
    string Email,
    string Token
);