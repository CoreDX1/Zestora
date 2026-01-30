using Zestora.Application.Models.Requests;
using Zestora.Application.Models.Responses;

namespace Zestora.Application.Interfaces;

public interface ICustomerService
{
    Task<CreateUserResponse> CreateUser(CreateUserRequest req);
    Task<ValidateUserResponse> ValidateUser(ValidateUserRequest req);
    Task<GetAllActiveUsersResponse> GetAllActiveUsers();
}
