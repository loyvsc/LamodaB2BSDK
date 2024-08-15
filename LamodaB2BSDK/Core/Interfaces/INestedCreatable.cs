namespace LamodaB2BSDK.Core.Interfaces;

public interface INestedCreatable<TEntity>
    where TEntity : class
{
    TEntity Create(TEntity entity);

    Task<TEntity> CreateAsync(TEntity entity, CancellationToken? cancellationToken = default);
}