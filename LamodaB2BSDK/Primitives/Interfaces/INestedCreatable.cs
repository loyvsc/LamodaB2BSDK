namespace LamodaB2BSDK.Primitives.Interfaces;

public interface INestedCreatable<TEntity>
    where TEntity : class
{
    TEntity Create(string url, TEntity entity);

    Task<TEntity> CreateAsync(string url, TEntity entity, CancellationToken? cancellationToken = default);
}