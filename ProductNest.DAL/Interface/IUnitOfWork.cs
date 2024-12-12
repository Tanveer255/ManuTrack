using ProductNest.Entity.Data;

namespace ProductNest.DAL.Interface;

/// <summary>
/// Unit Of Work interface.
/// </summary>
public interface IUnitOfWork : IDisposable
{
    /// <summary>
    /// Gets context property.
    /// </summary>
    public ProductNestDbContext Context { get; }

    /// <summary>
    /// Commit.
    /// </summary>
    public void Commit();
}
