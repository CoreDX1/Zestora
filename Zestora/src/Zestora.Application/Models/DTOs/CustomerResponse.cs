namespace Zestora.Application.Models.DTOs;

/// <summary>
/// Response containing customer information.
/// </summary>
public record CustomerResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    bool Active,
    DateTime RegisteredAt
);
