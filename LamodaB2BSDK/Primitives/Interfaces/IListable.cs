using LamodaB2BSDK.Requests.Options;

namespace LamodaB2BSDK.Primitives.Interfaces;

public interface IListable<TEntity, in TOptions>
    where TEntity : class
    where TOptions : ListOptions
{
    List<TEntity> List(TOptions? listOptions = null);

    Task<List<TEntity>> ListAsync(TOptions? listOptions = null, CancellationToken cancellationToken = default);

    IEnumerable<TEntity> ListAutoPaging(TOptions? listOptions = null);

    IAsyncEnumerable<TEntity> ListAutoPagingAsync(TOptions? listOptions = null, CancellationToken cancellationToken = default);
}