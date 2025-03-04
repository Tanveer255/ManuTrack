namespace ProductNest.Repository;
public interface IUnitOfMeasureRepository : IRepository<UnitOfMeasure>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    public Task<UnitOfMeasure> GetById(string code);
}
public class UnitOfMeasureRepository(
    IUnitOfWork unitOfWork,
    ILogger<UnitOfMeasureRepository> logger
    ) : Repository<UnitOfMeasure>(unitOfWork, logger), IUnitOfMeasureRepository
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ILogger<UnitOfMeasureRepository> _logger = logger;
    public async Task<UnitOfMeasure> GetById(string code)
    {
        var unitOfMeasure = new UnitOfMeasure();
        try
        {
            _logger.LogError("Getting bOMItem by Id");
            unitOfMeasure = (from uom in _unitOfWork.Context.UnitOfMeasures
                       where
                       uom.Code.Equals(code)
                       select new UnitOfMeasure
                       {
                           Code = uom.Code,
                           Name = uom.Name,
                       }).FirstOrDefault();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message, ex.InnerException, ex.InnerException != null ? ex.InnerException.Message : string.Empty);
            throw new Exception(ex.Message, ex.InnerException);
        }
        _logger.LogError("Returning unitOfMeasure :" + unitOfMeasure);
        return await Task.FromResult(unitOfMeasure);
    }
}
