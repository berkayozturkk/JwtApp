using AutoMapper;
using JwtApp.Core.Application.Dto;
using JwtApp.Core.Domain;

namespace JwtApp.Core.Application.Mappings;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product,ProductDto>().ReverseMap();
    }
}
