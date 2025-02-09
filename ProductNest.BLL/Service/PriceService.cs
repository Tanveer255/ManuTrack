namespace ProductNest.BLL.Service;
public class PriceService(
    IPriceRepository priceRepository,
         IUnitOfWork unitOfWork,
         IHttpContextAccessor httpContextAccessor
    ) : CrudService<Price>(priceRepository, unitOfWork), IPriceService
{
    private readonly IPriceRepository _priceRepository = priceRepository;
    private readonly IUnitOfWork _unitOfWork =unitOfWork;
    private readonly HttpContext _httpContext = httpContextAccessor.HttpContext;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<Price> GetById(Guid id)
    {
        var result = await _priceRepository.GetById(id);
        return result;
    }
}
