

namespace ProductNestService.Service.Manufacturing;
public interface IImpactedComponentService : ICrudService<ImpactedComponent>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<ImpactedComponent> GetById(Guid id);
    public Task<List<ImpactedComponent>> GetAllDataAsync();
}

public class ImpactedComponentService(
    IImpactedComponentRepository impactedComponentRepository,
         IUnitOfWork unitOfWork,
         IHttpContextAccessor httpContextAccessor
    ) : CrudService<ImpactedComponent>(impactedComponentRepository, unitOfWork), IImpactedComponentService
{
    private readonly IImpactedComponentRepository _impactedComponentRepository = impactedComponentRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly HttpContext _httpContext = httpContextAccessor.HttpContext;
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
