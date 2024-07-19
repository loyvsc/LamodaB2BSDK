namespace LamodaB2BSDK.Primitives.Interfaces;

public interface INestedUpdatable<TEntity>
    where TEntity : ILamodaEntity
{
    TEntity Update(string url, TEntity entity);

    Task<TEntity> UpdateAsync(string url, TEntity entity, CancellationToken? cancellationToken = default);
}