namespace AcessFlowService.Repository;
/// <summary>
/// Unit Of Work interface.
/// </summary>
public interface IUnitOfWork : IDisposable
{
    /// <summary>
    /// Gets context property.
    /// </summary>
    public AcessFlowServiceDbContext Context { get; }

    /// <summary>
    /// Commit.
    /// </summary>
    public void Commit();
}

/// <summary>
/// Class of UnitOfWork.
/// </summary>
public class UnitOfWork : IUnitOfWork
{
    private readonly ILogger<UnitOfWork> _logger;

    /// <summary>
    /// Gets this is DBContext class.
    /// </summary>
    public AcessFlowServiceDbContext Context { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
    /// </summary>
    /// <param name="context">object of ApplicationDbContext.</param>
    /// <param name="logger">object of ILogger.</param>
    public UnitOfWork(AcessFlowServiceDbContext context, ILogger<UnitOfWork> logger)
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
        catch (Exception exception)
        {
            _logger.LogError(exception, exception.Message, exception.InnerException, exception.InnerException != null ? exception.InnerException.Message : string.Empty);
            throw new Exception(exception.Message, exception.InnerException);
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