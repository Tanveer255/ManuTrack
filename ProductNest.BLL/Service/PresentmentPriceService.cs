namespace ProductNest.BLL.Service;

public class PresentmentPriceService(
    IPresentmentPriceRepository presentmentPriceRepository,
         IUnitOfWork unitOfWork,
         IHttpContextAccessor httpContextAccessor
    ) : CrudService<PresentmentPrice>(presentmentPriceRepository, unitOfWork), IPresentmentPriceService
{
    private readonly IPresentmentPriceRepository _presentmentPriceRepository = presentmentPriceRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly HttpContext _httpContext = httpContextAccessor.HttpContext;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<PresentmentPrice> GetById(Guid id)
    {
        var result = await _presentmentPriceRepository.GetById(id);
        return result;
    }
}
