namespace Zestora.Application.Models.Responses;

/// <summary>
/// Response containing user validation result.
/// </summary>
public record ValidateUserResponse(bool IsValid, Guid? UserId = null, string? Email = null);
