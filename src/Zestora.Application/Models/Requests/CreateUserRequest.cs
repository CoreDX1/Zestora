using System.ComponentModel.DataAnnotations;

namespace Zestora.Application.Models.Requests;

/// <summary>
/// Request for creating a new user account.
/// </summary>
public record CreateUserRequest(
    [Required] [MaxLength(100)] string FirstName,
    [Required] [MaxLength(100)] string LastName,
    [Required] [EmailAddress] string Email,
    [Required] [MinLength(8)] string Password
);
