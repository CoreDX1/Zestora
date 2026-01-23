using Zestora.Application.Models.Requests;
using Zestora.Application.Models.Responses;

namespace Zestora.Application.Interfaces;

public interface IUserService
{
    Task<CreateUserRes> CreateUser(CreateUserReq req);
    Task<ValidateUserRes> ValidateUser(ValidateUserReq req);
    Task<GetAllActiveUsersRes> GetAllActiveUsers();
}
