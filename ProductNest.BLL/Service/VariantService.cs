namespace ProductNest.BLL.Service;
public class VariantService(
    IVariantRepository variantRepository,
         IUnitOfWork unitOfWork,
         IHttpContextAccessor httpContextAccessor
    ) : CrudService<Variant>(variantRepository, unitOfWork), IVariantService
{
    private readonly IVariantRepository _variantRepository = variantRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly HttpContext _httpContext = httpContextAccessor.HttpContext;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<Variant> GetById(Guid id)
    {
        var result = await _variantRepository.GetById(id);
        return result;
    }
    public async Task<List<Variant>> GetAllDataAsync()
    {
        var result = await _unitOfWork.Context.Variants.ToListAsync();
        return result;
    }
}
