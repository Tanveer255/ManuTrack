namespace ProductNest.BLL.Service;

public class InventoryService : CrudService<Inventory>, IInventoryService
{
    private readonly IInventoryRepository _inventoryRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly HttpContext _httpContext;
    public InventoryService(IInventoryRepository inventoryRepository,
         IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        : base(inventoryRepository, unitOfWork)
    {
        _inventoryRepository = inventoryRepository;
        _unitOfWork = unitOfWork;
        _httpContext = httpContextAccessor.HttpContext;
    }
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
