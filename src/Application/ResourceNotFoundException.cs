namespace Application;

public sealed class ResourceNotFoundException<TEntity, TId>(TId entityId)
    : Exception($"{typeof(TEntity).Name} with id '{entityId}' not found");