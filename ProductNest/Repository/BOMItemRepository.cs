namespace ProductNestService.Repository;
public interface IBOMItemRepository : IRepository<BOMItem>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<BOMItem> GetById(Guid id);
}

public class BOMItemRepository(
    IUnitOfWork unitOfWork,
    ILogger<BOMItemRepository> logger
    ) : Repository<BOMItem>(unitOfWork, logger), IBOMItemRepository
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ILogger<BOMItemRepository> _logger = logger;
    public async Task<BOMItem> GetById(Guid id)
    {
        BOMItem bOMItem = new BOMItem();
        try
        {
            _logger.LogError("Getting bOMItem by Id");
            bOMItem = (from bom in _unitOfWork.Context.BOMItems
                       where
                       bom.Id.Equals(id)
                       && bom.IsDeleted.Equals(false)

                       select new BOMItem
                       {
                           BomItemId = bom.BomItemId,
                           MaterialName = bom.MaterialName,
                           InventoryId = bom.InventoryId,
                           UnitOfMeasure = bom.UnitOfMeasure,
                           ProductId = bom.ProductId,
                           Version = bom.Version,
                       }).FirstOrDefault();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message, ex.InnerException, ex.InnerException != null ? ex.InnerException.Message : string.Empty);
            throw new Exception(ex.Message, ex.InnerException);
        }
        _logger.LogError("Returning bOMItem :" + bOMItem);
        return await Task.FromResult(bOMItem);
    }
}
