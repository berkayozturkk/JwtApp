using AutoMapper;
using JwtApp.Core.Application.Dto;
using JwtApp.Core.Application.Features.CQRS.Command;
using JwtApp.Core.Application.Interfaces;
using JwtApp.Core.Domain;
using MediatR;

namespace JwtApp.Core.Application.Features.CQRS.Handlers;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, Result>
{
    private readonly IRepository<Product> _repository;

    public UpdateProductCommandHandler(IRepository<Product> repository)
    {
        _repository = repository;
    }

    public async Task<Result> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
    {
        Product product = await _repository.GetByIdAsync(request.Id);

        if(product is null)
            new ArgumentNullException(nameof(product) + "is not found");

        product.CategoryId = request.CategoryId;
        product.Name = request.Name;
        product.Price = request.Price;
        product.Stock = request.Stock;
       
        await _repository.UpdateAsync(product);
        return new Result(true);
    }
}

