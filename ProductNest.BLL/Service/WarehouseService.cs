namespace ProductNest.BLL.Service;

public class WarehouseService(
    IWarehouseRepository warehouseRepository,
         IUnitOfWork unitOfWork,
         IHttpContextAccessor httpContextAccessor
    ) : CrudService<Warehouse>(warehouseRepository, unitOfWork), IWarehouseService
{
    private readonly IWarehouseRepository _warehouseRepository = warehouseRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly HttpContext _httpContext = httpContextAccessor.HttpContext;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<Warehouse> GetById(Guid id)
    {
        var result = await _warehouseRepository.GetByIdAsync(id);
        return result;
    }
    public async Task<List<Warehouse>> GetAllDataAsync()
    {
        var result = await _unitOfWork.Context.Warehouse.ToListAsync();
        return result;
    }
}