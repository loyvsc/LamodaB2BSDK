using LamodaB2BSDK.Core.Responses;
using OneOf;

namespace LamodaB2BSDK.Core.Interfaces;

public interface IRetrievable<TEntity>
    where TEntity : IHasId
{
    OneOf<TEntity,ErrorResponse> Get(string id);

    Task<OneOf<TEntity,ErrorResponse>> GetAsync(string id, CancellationToken cancellationToken = default);
}