using Zestora.Application.Interfaces;
using Zestora.Application.Models.DTOs;
using Zestora.Application.Models.Requests;
using Zestora.Application.Models.Responses;
using Zestora.Domain.Core.Repositories;
using Zestora.Domain.Entities;

namespace Zestora.Application.Services;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<CreateUserRes> CreateUser(CreateUserReq req)
    {
        var customerRepo = _unitOfWork.Repository<Customer>();

        var customer = new Customer
        {
            Id = Guid.NewGuid(),
            FirstName = req.FirstName,
            LastName = req.LastName,
            Email = req.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(req.Password),
            Active = true,
            RegisteredAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
        };

        await customerRepo.AddAsync(customer);
        await _unitOfWork.SaveChangesAsync();

        return new CreateUserRes { Data = new CustomerDTO(customer) };
    }

    public async Task<ValidateUserRes> ValidateUser(ValidateUserReq req)
    {
        var customerRepo = _unitOfWork.Repository<Customer>();
        var customers = await customerRepo.ListAllAsync();

        var customer = customers.FirstOrDefault(c => c.Email == req.Email && c.Active == true);

        if (customer == null || !BCrypt.Net.BCrypt.Verify(req.Password, customer.PasswordHash))
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
        var customerRepo = _unitOfWork.Repository<Customer>();
        var customers = await customerRepo.ListAllAsync();

        var activeUsers = customers
            .Where(c => c.Active == true)
            .Select(c => new CustomerDTO(c))
            .ToList();

        return new GetAllActiveUsersRes { Users = activeUsers };
    }
}
