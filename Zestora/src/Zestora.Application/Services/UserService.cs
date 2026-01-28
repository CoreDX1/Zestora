using Zestora.Application.Interfaces;
using Zestora.Application.Models.DTOs;
using Zestora.Application.Models.Requests;
using Zestora.Application.Models.Responses;
using Zestora.Domain.Builders;
using Zestora.Domain.Core.Repositories;
using Zestora.Domain.Entities;

namespace Zestora.Application.Services;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordHasher _passwordHasher;

    public UserService(IUnitOfWork unitOfWork, IPasswordHasher passwordHasher)
    {
        _unitOfWork = unitOfWork;
        _passwordHasher = passwordHasher;
    }

    public async Task<CreateUserRes> CreateUser(CreateUserReq req)
    {
        string passwordHash = _passwordHasher.Hash(req.Password);

        Customer customer = new CustomerBuilder()
            .WithPersonalData(req.FirstName, req.LastName)
            .WithCredentials(req.Email, passwordHash)
            .AsActive()
            .Build();

        await _unitOfWork.Customer.AddAsync(customer);
        await _unitOfWork.SaveChangesAsync();

        return new CreateUserRes { Data = new CustomerDTO(customer) };
    }

    public async Task<ValidateUserRes> ValidateUser(ValidateUserReq req)
    {
        Customer customer = await _unitOfWork.Customer.GetCustomerByEmail(req.Email);

        if (customer == null || !_passwordHasher.Verify(req.Password, customer.PasswordHash))
        {
            return new ValidateUserRes { IsValid = false };
        }

        return new ValidateUserRes
        {
            IsValid = true,
            UserId = customer.Id,
            Email = customer.Email,
        };
    }

    public async Task<GetAllActiveUsersRes> GetAllActiveUsers()
    {
        IEnumerable<Customer> customer = await _unitOfWork.Customer.GetAllActiveCustomers();
        IEnumerable<CustomerDTO> activeUsers = customer.Select(c => new CustomerDTO(c));

        return new GetAllActiveUsersRes { Users = activeUsers };
    }
}
