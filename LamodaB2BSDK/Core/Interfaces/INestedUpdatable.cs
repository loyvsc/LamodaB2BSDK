﻿namespace LamodaB2BSDK.Core.Interfaces;

public interface INestedUpdatable<TEntity>
    where TEntity : class
{
    TEntity Update(string url, TEntity entity);

    Task<TEntity> UpdateAsync(string url, TEntity entity, CancellationToken? cancellationToken = default);
}