namespace CarJournal.Api.Authentication;

public record RegisterRequest(
    string Email,
    string Password
);