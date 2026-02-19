using Zestora.Application.Models.DTOs;

namespace Zestora.Application.Models.Responses;

/// <summary>
/// Response containing all active users.
/// </summary>
/// <param name="Users"></param>
public record GetAllActiveUsersResponse(IEnumerable<CustomerResponse> Users);
