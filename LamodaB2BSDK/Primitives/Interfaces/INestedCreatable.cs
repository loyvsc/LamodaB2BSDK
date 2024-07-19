namespace LamodaB2BSDK.Primitives.Interfaces;

public interface INestedCreatable<TEntity>
    where TEntity : ILamodaEntity
{
    TEntity Create(string url, TEntity entity);

    Task<TEntity> CreateAsync(string url, TEntity entity, CancellationToken? cancellationToken = default);
}