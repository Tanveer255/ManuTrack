namespace ProductNestService.BLL.Service;
public interface IUnitOfMeasureService : ICrudService<UnitOfMeasure>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    public Task<UnitOfMeasure> GetById(string code);
    public Task<List<UnitOfMeasure>> GetAllDataAsync();
    public Task<UnitOfMeasure> AddUpdate(UnitOfMeasure uom);
}
public class UnitOfMeasureService(
    IUnitOfMeasureRepository unitOfMeasureRepository,
         IUnitOfWork unitOfWork,
         IHttpContextAccessor httpContextAccessor
    ) : CrudService<UnitOfMeasure>(unitOfMeasureRepository, unitOfWork), IUnitOfMeasureService
{
    private readonly IUnitOfMeasureRepository _unitOfMeasureRepository = unitOfMeasureRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly HttpContext _httpContext = httpContextAccessor.HttpContext;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<UnitOfMeasure> GetById(string code)
    {
        var result = await _unitOfMeasureRepository.GetById(code);
        return result;
    }
    public async Task<List<UnitOfMeasure>> GetAllDataAsync()
    {
        var result = await _unitOfWork.Context.UnitOfMeasures.ToListAsync();
        return result;
    }
    public async Task<UnitOfMeasure> AddUpdate(UnitOfMeasure uom)
    {
        var result = await UnitOfMeasureExist(uom.Code);
        if (result)
        {
            await _unitOfMeasureRepository.Add(uom);
            _unitOfWork.Commit();
            return uom;
        }
        await _unitOfMeasureRepository.Update(uom);
        _unitOfWork.Commit();
        return uom;
    }
    public async Task<bool> UnitOfMeasureExist(string code)
    {
        var result = await _unitOfWork.Context.UnitOfMeasures.FindAsync(code);
        if (result != null)
            return true;
        return false;
    }
}