using CSharpFunctionalExtensions;
using Onix.SharedKernel;

namespace Onix.Core.Abstraction;

public interface IQueryHandler<TResponse, in TQuery> where TQuery : IQuery
{
    public Task<TResponse> Handle(TQuery query, CancellationToken cancellationToken = default);
}

public interface IQueryHandlerWithResult<TResponse, in TQuery> where TQuery : IQuery
{
    public Task<Result<TResponse, ErrorList>> Handle(TQuery command, CancellationToken cancellationToken = default);
}