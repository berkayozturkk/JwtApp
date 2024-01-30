using AutoMapper;
using JwtApp.Core.Application.Dto;
using JwtApp.Core.Application.Features.CQRS.Queries;
using JwtApp.Core.Application.Interfaces;
using JwtApp.Core.Domain;
using MediatR;

namespace JwtApp.Core.Application.Features.CQRS.Handlers;

public class GetProductQueryHandler
    : IRequestHandler<GetProductQueryRequest,ProductDto>
{
    private readonly IRepository<Product> _repository;
    private readonly IMapper _mapper;

    public GetProductQueryHandler(IRepository<Product> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ProductDto> Handle(GetProductQueryRequest request, CancellationToken cancellationToken)
    {
        var product = await _repository.GetByFilterAsync(x => x.Id == request.Id);

        return _mapper.Map<ProductDto>(product);
    }
}

public class GetCategoryQueryHandler
    : IRequestHandler<GetCategoryQueryRequest, CategoryDto>
{
    private readonly IRepository<Category> _repository;
    private readonly IMapper _mapper;

    public GetCategoryQueryHandler(IRepository<Category> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<CategoryDto> Handle(GetCategoryQueryRequest request, CancellationToken cancellationToken)
    {
        var category = await _repository.GetByFilterAsync(x => x.Id == request.Id);

        return _mapper.Map<CategoryDto>(category);
    }
}
