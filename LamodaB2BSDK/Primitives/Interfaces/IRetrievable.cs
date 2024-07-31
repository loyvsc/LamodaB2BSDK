namespace LamodaB2BSDK.Primitives.Interfaces;

public interface IRetrievable<TEntity>
    where TEntity : IHasId
{
    TEntity Get(string id);

    Task<TEntity> GetAsync(string id, CancellationToken cancellationToken = default);
}