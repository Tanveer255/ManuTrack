namespace ProductNest.BLL.Service;

public class PresentmentPriceService : CrudService<PresentmentPrice>, IPresentmentPriceService
{
    private readonly IPresentmentPriceRepository _presentmentPriceRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly HttpContext _httpContext;
    public PresentmentPriceService(IPresentmentPriceRepository presentmentPriceRepository,
         IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        : base(presentmentPriceRepository, unitOfWork)
    {
        _presentmentPriceRepository = presentmentPriceRepository;
        _unitOfWork = unitOfWork;
        _httpContext = httpContextAccessor.HttpContext;
    }
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
