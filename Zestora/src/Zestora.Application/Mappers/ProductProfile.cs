using AutoMapper;
using Zestora.Application.Models.Responses;
using Zestora.Domain.Entities;

namespace Zestora.Application.Mappers;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, CreateProductResponse>();

        CreateMap<Product, ProductResponse>()
            .ForMember(
                dest => dest.ProductType,
                opt => opt.MapFrom(src => src.ProductType ?? "simple")
            );
    }
}
