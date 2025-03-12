namespace ProductNestService.Repository.Manufacturing;
public interface IImpactedComponentRepository : IRepository<ImpactedComponent>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<ImpactedComponent> GetById(Guid id);
}
public class ImpactedComponentRepository(
    IUnitOfWork unitOfWork,
    ILogger<ImpactedComponentRepository> logger
    ) : Repository<ImpactedComponent>(unitOfWork, logger), IImpactedComponentRepository
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ILogger<ImpactedComponentRepository> _logger = logger;
    public async Task<ImpactedComponent> GetById(Guid Id)
    {
        ImpactedComponent impactedComponent = new ImpactedComponent();
        try
        {
            _logger.LogError("Getting batchs by Id");
            impactedComponent = (from ic in _unitOfWork.Context.ImpactedComponents
                     where
                     ic.Id.Equals(Id)
                     && ic.IsDeleted.Equals(false)

                     select new ImpactedComponent
                     {
                         Id = ic.Id,
                         ImpactedComponentId = ic.ImpactedComponentId,
                         IsDeleted = ic.IsDeleted,
                         CreatedAt = ic.CreatedAt,
                         UpdatedAt = ic.UpdatedAt,
                         BatchId = ic.BatchId,
                         Batch = ic.Batch,
                         BOMItemId = ic.BOMItemId,
                         IsPicked = ic.IsPicked,
                         ImpactType = ic.ImpactType,
                         Direction = ic.Direction,
                         WarehouseId = ic.WarehouseId,
                         Warehouse = ic.Warehouse,
                         InventoryId = ic.InventoryId,
                         Inventory = ic.Inventory,

                     }).FirstOrDefault();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message, ex.InnerException, ex.InnerException != null ? ex.InnerException.Message : string.Empty);
            throw new Exception(ex.Message, ex.InnerException);
        }
        _logger.LogError("Returning ImpactedComponent :" + impactedComponent);
        return await Task.FromResult(impactedComponent);
    }
}
