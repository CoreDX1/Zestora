using System.ComponentModel.DataAnnotations;

namespace Zestora.Application.Models.Requests;

/// <summary>
/// Request for validating user credentials during login.
/// </summary>
public record ValidateUserRequest(
    [EmailAddress] [Required] string Email,
    [Required] [MinLength(5)] string Password
);
