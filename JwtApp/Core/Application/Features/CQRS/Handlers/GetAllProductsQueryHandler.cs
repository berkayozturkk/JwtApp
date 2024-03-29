﻿using AutoMapper;
using JwtApp.Core.Application.Dto;
using JwtApp.Core.Application.Features.CQRS.Queries;
using JwtApp.Core.Application.Interfaces;
using JwtApp.Core.Domain;
using MediatR;

namespace JwtApp.Core.Application.Features.CQRS.Handlers;

public class GetAllProductsQueryHandler
    : IRequestHandler<GetAllProductsQueryRequest, List<ProductDto>>
{
    private readonly IRepository<Product> _repository;
    private readonly IMapper _mapper;

    public GetAllProductsQueryHandler(IRepository<Product> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<ProductDto>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
    {
        var allProductList = await _repository.GetAllAsync();
        return _mapper.Map<List<ProductDto>>(allProductList);
    }
}
