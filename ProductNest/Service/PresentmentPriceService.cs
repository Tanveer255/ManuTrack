namespace ProductNest.BLL.Service;
public interface IPresentmentPriceService : ICrudService<PresentmentPrice>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    public Task<PresentmentPrice> GetById(Guid Id);
}
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
