namespace Zestora.Domain.Core.Models;

public enum ErrorType
{
    NotFound,
    Validation,
    Unauthorized,
}

public record Error(string Id, ErrorType Type, string Description);

public static class Errors
{
    public static Error AccountNotFound { get; } =
        new("AccountNotFound", ErrorType.NotFound, "Account not found.");
    public static Error InsufficientFunds { get; } =
        new("InsufficientFunds", ErrorType.Validation, "Insufficient balance.");

    public static Error ProductNotFound { get; } =
        new("ProductNotFound", ErrorType.NotFound, "Product not found.");
}
