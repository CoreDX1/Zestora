namespace Zestora.Application.Models.Responses;

public class ValidateUserRes
{
    public bool IsValid { get; set; }
    public Guid? UserId { get; set; }
    public string? Email { get; set; }
}
