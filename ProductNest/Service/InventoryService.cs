namespace ProductNest.BLL.Service;
public interface IInventoryService : ICrudService<Inventory>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    public Task<Inventory> GetById(Guid Id);
}
public class InventoryService(
    IInventoryRepository inventoryRepository,
         IUnitOfWork unitOfWork,
         IHttpContextAccessor httpContextAccessor
    ) : CrudService<Inventory>(inventoryRepository, unitOfWork), IInventoryService
{
    private readonly IInventoryRepository _inventoryRepository = inventoryRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly HttpContext _httpContext = httpContextAccessor.HttpContext;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<Inventory> GetById(Guid id)
    {
        var result = await _inventoryRepository.GetById(id);
        return result;
    }
}
