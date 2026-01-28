using Zestora.Application.Models.DTOs;

namespace Zestora.Application.Models.Responses;

public class CreateUserRes
{
    public required CustomerDTO Data { get; set; }
}
