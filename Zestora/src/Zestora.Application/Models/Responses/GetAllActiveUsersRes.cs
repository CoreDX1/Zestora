using Zestora.Application.Models.DTOs;

namespace Zestora.Application.Models.Responses;

public class GetAllActiveUsersRes
{
    public IEnumerable<CustomerDTO> Users { get; set; } = [];
}
