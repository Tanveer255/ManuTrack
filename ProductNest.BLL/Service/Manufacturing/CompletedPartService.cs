namespace ProductNest.BLL.Service.Manufacturing;

public class CompletedPartService : CrudService<CompletedPart>, ICompletedPartService
{
    private readonly ICompletedPartRepository _completedPartRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly HttpContext _httpContext;
    public CompletedPartService(ICompletedPartRepository completedPartRepository,
         IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        : base(completedPartRepository, unitOfWork)
    {
        _completedPartRepository = completedPartRepository;
        _unitOfWork = unitOfWork;
        _httpContext = httpContextAccessor.HttpContext;
    }
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
