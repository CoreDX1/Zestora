namespace Zestora.Application.Models.Responses;

/// <summary>
/// Response after successfully creating a user.
/// </summary>
public record CreateUserResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    DateTime RegisteredAt
);
