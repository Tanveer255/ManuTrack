namespace ProductNest.BLL.Service;

public class BOMItemService(
    IBOMItemRepository bOMItemRepository,
         IUnitOfWork unitOfWork,
         IHttpContextAccessor httpContextAccessor
    ) : CrudService<BOMItem>(bOMItemRepository, unitOfWork), IBOMItemService
{
    private readonly IBOMItemRepository _bOMItemRepository = bOMItemRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly HttpContext _httpContext = httpContextAccessor.HttpContext;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<BOMItem> GetById(Guid id)
    {
        var result = await _bOMItemRepository.GetById(id);
        return result;
    }
    public async Task<List<BOMItem>> GetAllDataAsync()
    {
        var result = await _unitOfWork.Context.BOMItems.ToListAsync();
        return result;
    }
}
