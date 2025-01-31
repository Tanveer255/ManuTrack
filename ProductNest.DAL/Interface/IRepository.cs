namespace ProductNest.DAL.Interface;

/// <summary>
/// IRepository interface.
/// </summary>
/// <typeparam name="T">object of IRepository.</typeparam>
public interface IRepository<T>
{
    /// <summary>
    /// For adding.
    /// </summary>
    /// <param name="entity">is an entity model.</param>
    /// <returns>Returns result.</returns>
    public Task Add(T entity);

    /// <summary>
    /// For adding list.
    /// </summary>
    /// <param name="entities">is an entity model.</param>
    /// <returns>Returns result.</returns>
    public Task Add(IEnumerable<T> entities);

    /// <summary>
    /// For Deleting list.
    /// </summary>
    /// <param name="entities">is an entity model.</param>
    /// <returns>Returns result.</returns>
    public Task Delete(IEnumerable<T> entities);


    /// <summary>
    /// For updating.
    /// </summary>
    /// <param name="entity">is an entity model.</param>
    /// <returns>Returns result.</returns>
    public Task Update(T entity);

    /// <summary>
    /// For updating list.
    /// </summary>
    /// <param name="entities">is an entity model.</param>
    /// <returns>Returns result.</returns>
    public Task Update(IEnumerable<T> entities);

    /// <summary>
    /// For getting.
    /// </summary>
    /// <returns>Returns result.</returns>
    public Task<IEnumerable<T>> Get();

    /// <summary>
    /// For getting single item.
    /// </summary>
    /// <param name="predicate">Param, check weather.</param>
    /// <returns>Returns result.</returns>
    public Task<T> GetSingle(Expression<Func<T, bool>> predicate);

    /// <summary>
    /// For getting.
    /// </summary>
    /// <param name="predicate">Param, check weather.</param>
    /// <returns>Returns result.</returns>
    public Task<IEnumerable<T>> Get(Expression<Func<T, bool>> predicate);

    /// <summary>
    /// For deleting.
    /// </summary>
    /// <param name="entity">is an entity model.</param>
    /// <returns>Returns result.</returns>
    public Task Delete(T entity);
    /// <summary>
    /// Discard single item parmanantly
    /// </summary>
    /// <param name="entities"></param>
    /// <returns></returns>
    public Task Discard(T entities);
    /// <summary>
    /// Discard list parmanantly
    /// </summary>
    /// <param name="entities"></param>
    /// <returns></returns>
    public Task Discard(IEnumerable<T> entities);
    IQueryable<T> GetAllReadOnly();
}
