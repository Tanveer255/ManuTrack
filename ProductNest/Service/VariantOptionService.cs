namespace ProductNest.BLL.Service;
public interface IVariantOptionService : ICrudService<VariantOption>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    public Task<VariantOption> GetById(Guid Id);
    public Task<List<VariantOption>> GetAllDataAsync();
}
public class VariantOptionService(
    IVariantOptionRepository variantOptionRepository,
         IUnitOfWork unitOfWork,
         IHttpContextAccessor httpContextAccessor
    ) : CrudService<VariantOption>(variantOptionRepository, unitOfWork), IVariantOptionService
{
    private readonly IVariantOptionRepository _variantOptionRepository = variantOptionRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly HttpContext _httpContext = httpContextAccessor.HttpContext;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<VariantOption> GetById(Guid id)
    {
        var result = await _variantOptionRepository.GetById(id);
        return result;
    }
    public async Task<List<VariantOption>> GetAllDataAsync()
    {
        var result = await _unitOfWork.Context.VariantOption.ToListAsync();
        return result;
    }
}
