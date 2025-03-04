namespace ProductNest.Service.Manufacturing;
public interface ICompletedPartService : ICrudService<CompletedPart>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<CompletedPart> GetById(Guid id);
    public Task<List<CompletedPart>> GetAllDataAsync();
}
public class CompletedPartService(
    ICompletedPartRepository completedPartRepository,
         IUnitOfWork unitOfWork,
IHttpContextAccessor httpContextAccessor
    ) : CrudService<CompletedPart>(completedPartRepository, unitOfWork), ICompletedPartService
{
    private readonly ICompletedPartRepository _completedPartRepository = completedPartRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly HttpContext _httpContext = httpContextAccessor.HttpContext;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="productId"></param>
    /// <returns></returns>
    public async Task<CompletedPart> GetById(Guid productId)
    {
        var result = await _completedPartRepository.GetById(productId);
        return result;
    }
    public async Task<List<CompletedPart>> GetAllDataAsync()
    {
        var result = await _unitOfWork.Context.CompletedParts.ToListAsync();
        return result;
    }
}
