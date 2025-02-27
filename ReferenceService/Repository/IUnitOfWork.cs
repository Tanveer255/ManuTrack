using ReferenceService.Data;

namespace ReferenceService.Repository;

/// <summary>
/// Unit Of Work interface.
/// </summary>
public interface IUnitOfWork : IDisposable
{
    /// <summary>
    /// Gets context property.
    /// </summary>
    public ReferenceServiceDbContext Context { get; }

    /// <summary>
    /// Commit.
    /// </summary>
    public void Commit();
}