using Zestora.Application.Models.DTOs;

namespace Zestora.Application.Models.Responses;

public class GetAllActiveUsersRes
{
    public List<CustomerDTO> Users { get; set; } = new();
}
