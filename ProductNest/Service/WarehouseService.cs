namespace ProductNest.BLL.Service;
public interface IWarehouseService : ICrudService<Warehouse>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    public Task<Warehouse> GetById(Guid Id);
    public Task<Warehouse> AddUpdate(Warehouse warehouse);
    public Task<List<Warehouse>> GetAllDataAsync();
}

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
    public async Task<Warehouse> AddUpdate(Warehouse warehouse)
    {
        var warehouseExist = await WareHouseExist(warehouse.Id);
        if (warehouseExist)
        {
            await _warehouseRepository.Add(warehouse);
            _unitOfWork.Commit();
            return warehouse;
        }
        await _warehouseRepository.Update(warehouse);
        _unitOfWork.Commit();
        return warehouse;
    }
    public async Task<bool> WareHouseExist(Guid id)
    {
        var result = await _unitOfWork.Context.Warehouse.FindAsync(id);
        if (result != null)
            return true;
        return false;
    }
    public async Task<List<Warehouse>> GetAllDataAsync()
    {
        var result = await _unitOfWork.Context.Warehouse.ToListAsync();
        return result;
    }
}