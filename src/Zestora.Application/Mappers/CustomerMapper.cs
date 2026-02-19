using Zestora.Application.Models.DTOs;
using Zestora.Application.Models.Responses;
using Zestora.Domain.Entities;

namespace Zestora.Application.Mappers;

public static class CustomerMapper
{
    public static CustomerResponse ToResponse(this Customer customer) =>
        new(
            customer.Id,
            customer.FirstName,
            customer.LastName,
            customer.Email,
            customer.Active ?? false,
            customer.RegisteredAt
        );

    public static CreateUserResponse ToCreateResponse(this Customer customer) =>
        new(
            customer.Id,
            customer.FirstName,
            customer.LastName,
            customer.Email,
            customer.RegisteredAt
        );
}
