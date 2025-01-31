

namespace ProductNest.BLL.Service.Manufacturing;
public class ImpactedComponentService : CrudService<ImpactedComponent>, IImpactedComponentService
{
    private readonly IImpactedComponentRepository _impactedComponentRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly HttpContext _httpContext;
    public ImpactedComponentService(IImpactedComponentRepository impactedComponentRepository,
         IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        : base(impactedComponentRepository, unitOfWork)
    {
        _impactedComponentRepository = impactedComponentRepository;
        _unitOfWork = unitOfWork;
        _httpContext = httpContextAccessor.HttpContext;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="productId"></param>
    /// <returns></returns>
    public async Task<ImpactedComponent> GetById(Guid productId)
    {
        var result = await _impactedComponentRepository.GetById(productId);
        return result;
    }
    public async Task<List<ImpactedComponent>> GetAllDataAsync()
    {
        var result = await _unitOfWork.Context.ImpactedComponents.ToListAsync();
        return result;
    }
}
