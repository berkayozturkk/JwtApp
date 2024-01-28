using AutoMapper;
using JwtApp.Core.Application.Dto;
using JwtApp.Core.Application.Features.CQRS.Command;
using JwtApp.Core.Domain;

namespace JwtApp.Core.Application.Mappings;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product,ProductDto>().ReverseMap();
        CreateMap<Product, CreateProductCommandRequest>().ReverseMap();
    }
}
