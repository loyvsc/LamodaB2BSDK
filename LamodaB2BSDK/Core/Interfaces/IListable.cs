using LamodaB2BSDK.Core.Requests;
using LamodaB2BSDK.Core.Responses;
using OneOf;

namespace LamodaB2BSDK.Core.Interfaces;

public interface IListable<TEntity>
    where TEntity : class
{
    OneOf<IEnumerable<TEntity>,ErrorResponse> List(PaginationRequest listOptions);
    Task<OneOf<IEnumerable<TEntity>,ErrorResponse>> ListAsync(PaginationRequest listOptions, CancellationToken cancellationToken = default);
}