using System.Linq.Expressions;

namespace ProductNest.BLL.Interface;

public interface ICrudService<T>
{
    /// <summary>
    /// Method declration of ICrudService to add the Object.
    /// </summary>
    /// <param name="entity">General object to be add.</param>
    /// <returns>General object after adding.</returns>
    public Task<T> Add(T entity);

    /// <summary>
    /// For adding list.
    /// </summary>
    /// <param name="entities">is an entity model.</param>
    /// <returns>Returns result.</returns>
    public Task Add(IEnumerable<T> entities);

    /// <summary>
    /// For adding list.
    /// </summary>
    /// <param name="entities">is an entity model.</param>
    /// <returns>Returns result.</returns>
    public Task Delete(IEnumerable<T> entities);

    /// <summary>
    /// Method declration of ICrudService to update the Object.
    /// </summary>
    /// <param name="entity">General object to be update.</param>
    /// <returns>General object after updating.</returns>
    public Task<T> Update(T entity);

    /// <summary>
    /// For updating list.
    /// </summary>
    /// <param name="entities">is an entity model.</param>
    /// <returns>Returns result.</returns>
    public Task Update(IEnumerable<T> entities);

    /// <summary>
    /// Method declration of ICrudService to get the Object.
    /// </summary>
    /// <param name="entity">General object to be get.</param>
    /// <returns>General object after getting.</returns>
    public Task<IEnumerable<T>> Get();

    /// <summary>
    /// Method declration of ICrudService to get single Object.    
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public Task<T> GetSingle(Expression<Func<T, bool>> predicate);

    /// <summary>
    /// For getting.
    /// </summary>
    /// <param name="predicate">Param, check weather.</param>
    /// <returns>Returns result.</returns>
    public Task<IEnumerable<T>> Get(Expression<Func<T, bool>> predicate);

    /// <summary>
    /// Method declration of ICrudService to delete the Object.
    /// </summary>
    /// <param name="entity">General object to be delete.</param>
    /// <returns>General object after deleting.</returns>
    public Task<bool> Delete(T entity);
    /// <summary>
    /// Delete Permanantly
    /// </summary>
    /// <param name="entities"></param>
    /// <returns></returns>
    public Task Discard(IEnumerable<T> entities);
    /// <summary>
    ///  Discard parmanantly
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public Task Discard(T entity);
}
