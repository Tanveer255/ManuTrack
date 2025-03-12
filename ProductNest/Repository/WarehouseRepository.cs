namespace ProductNestService.Repository;
public interface IWarehouseRepository : IRepository<Warehouse>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<Warehouse> GetByIdAsync(Guid id);
}
public class WarehouseRepository(
    IUnitOfWork unitOfWork,
    ILogger<WarehouseRepository> logger
    ) : Repository<Warehouse>(unitOfWork, logger), IWarehouseRepository
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ILogger<WarehouseRepository> _logger = logger;
    public async Task<Warehouse> GetByIdAsync(Guid id)
    {
        try
        {
            _logger.LogInformation("Getting Warehouse by Id: {Id}", id);

            var warehouse = await (from ware in _unitOfWork.Context.Warehouse
                                   where ware.Id == id && !ware.IsDeleted
                                   select new Warehouse
                                   {
                                       WarehouseId = ware.WarehouseId,
                                       Zone = ware.Zone,
                                       Aisle = ware.Aisle,
                                       Location = ware.Location,
                                       Shelf = ware.Shelf,
                                       Rack = ware.Rack,
                                       Bay = ware.Bay,
                                       VariantId = ware.VariantId,
                                       Variant = ware.Variant,
                                       Inventory = ware.Inventory,
                                   }).FirstOrDefaultAsync();

            if (warehouse == null)
            {
                _logger.LogWarning("Warehouse with Id: {Id} not found.", id);
            }
            else
            {
                _logger.LogInformation("Returning Warehouse: {Warehouse}", warehouse);
            }

            return warehouse;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while fetching Warehouse with Id: {Id}", id);
            throw; // Re-throw the original exception to preserve the stack trace
        }
    }

}
