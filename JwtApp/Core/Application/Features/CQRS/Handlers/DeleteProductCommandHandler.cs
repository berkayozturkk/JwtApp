using AutoMapper;
using JwtApp.Core.Application.Dto;
using JwtApp.Core.Application.Features.CQRS.Command;
using JwtApp.Core.Application.Interfaces;
using JwtApp.Core.Domain;
using MediatR;

namespace JwtApp.Core.Application.Features.CQRS.Handlers;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, Result>
{
    private readonly IRepository<Product> _repository;

    public DeleteProductCommandHandler(IRepository<Product> repository)
    {
        _repository = repository;
    }

    public async Task<Result> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
    {
        var deletedEntity = await _repository.GetByIdAsync(request.Id);

        if (deletedEntity is null)
            throw new ArgumentNullException(nameof(deletedEntity) + "is not found");

        await _repository.RemoveAsync(deletedEntity);
        return new Result(true);
    }
}
