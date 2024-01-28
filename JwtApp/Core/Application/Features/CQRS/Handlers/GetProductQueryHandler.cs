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
