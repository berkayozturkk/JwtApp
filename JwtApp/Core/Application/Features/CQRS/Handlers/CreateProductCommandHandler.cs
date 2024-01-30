using AutoMapper;
using JwtApp.Core.Application.Dto;
using JwtApp.Core.Application.Features.CQRS.Command;
using JwtApp.Core.Application.Interfaces;
using JwtApp.Core.Domain;
using MediatR;

namespace JwtApp.Core.Application.Features.CQRS.Handlers;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, Result>
{
    private readonly IRepository<Product> _repository;
    private readonly IMapper _mapper;

    public CreateProductCommandHandler(IRepository<Product> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
    {
        //Product newProduct = _mapper.Map<Product>(request);

        Product newProduct = new()
        {
            Id = Guid.NewGuid().ToString(),
            Name = request.Name,
            Price = request.Price,
            Stock = request.Stock,
            CategoryId = request.CategoryId
        };

        await _repository.CreateAsync(newProduct);

        return new Result(true);
    }
}
