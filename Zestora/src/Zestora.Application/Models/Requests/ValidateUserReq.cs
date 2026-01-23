namespace Zestora.Application.Models.Requests;

public class ValidateUserReq
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}
