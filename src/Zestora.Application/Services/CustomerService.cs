using Zestora.Application.Interfaces;
using Zestora.Application.Mappers;
using Zestora.Application.Models.DTOs;
using Zestora.Application.Models.Requests;
using Zestora.Application.Models.Responses;
using Zestora.Domain.Builders;
using Zestora.Domain.Core.Repositories;
using Zestora.Domain.Entities;

namespace Zestora.Application.Services;

public class CustomerService : ICustomerService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordHasher _passwordHasher;

    public CustomerService(IUnitOfWork unitOfWork, IPasswordHasher passwordHasher)
    {
        _unitOfWork = unitOfWork;
        _passwordHasher = passwordHasher;
    }

    public async Task<CreateUserResponse> CreateUser(CreateUserRequest req)
    {
        string passwordHash = _passwordHasher.Hash(req.Password);

        Customer customer = new CustomerBuilder()
            .WithPersonalData(req.FirstName, req.LastName)
            .WithCredentials(req.Email, passwordHash)
            .AsActive()
            .Build();

        await _unitOfWork.Customer.AddAsync(customer);
        await _unitOfWork.SaveChangesAsync();

        return customer.ToCreateResponse();
    }

    public async Task<ValidateUserResponse> ValidateUser(ValidateUserRequest req)
    {
        Customer customer = await _unitOfWork.Customer.GetCustomerByEmail(req.Email);

        if (customer == null || !_passwordHasher.Verify(req.Password, customer.PasswordHash))
        {
            return new ValidateUserResponse(IsValid: false);
        }

        return new ValidateUserResponse(IsValid: true, UserId: customer.Id, Email: customer.Email);
    }

    public async Task<GetAllActiveUsersResponse> GetAllActiveUsers()
    {
        IEnumerable<Customer> customers = await _unitOfWork.Customer.GetAllActiveCustomers();
        IEnumerable<CustomerResponse> activeUsers = customers.Select(c => c.ToResponse());

        return new GetAllActiveUsersResponse(Users: activeUsers);
    }
}
