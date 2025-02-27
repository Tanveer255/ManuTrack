using ReferenceService.Data;

namespace ReferenceService.Repository;

/// <summary>
/// Class of UnitOfWork.
/// </summary>
public class UnitOfWork : IUnitOfWork
{
    private readonly ILogger<UnitOfWork> _logger;

    /// <summary>
    /// Gets this is DBContext class.
    /// </summary>
    public ReferenceServiceDbContext Context { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
    /// </summary>
    /// <param name="context">object of ApplicationDbContext.</param>
    /// <param name="logger">object of ILogger.</param>
    public UnitOfWork(ReferenceServiceDbContext context, ILogger<UnitOfWork> logger)
    {
        Context = context;
        _logger = logger;
    }

    /// <summary>
    /// Commit save changes.
    /// </summary>
    public void Commit()
    {
        try
        {
            _logger.LogInformation("Commit save changes");
            Context.SaveChanges();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message, ex.InnerException, ex.InnerException != null ? ex.InnerException.Message : string.Empty);
            throw new Exception(ex.Message, ex.InnerException);
        }
    }

    /// <summary>
    /// Dispose method.
    /// </summary>
    public void Dispose()
    {
        Context.Dispose();
    }
}