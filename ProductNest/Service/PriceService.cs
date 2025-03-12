namespace ProductNestService.BLL.Service;
public interface IPriceService : ICrudService<Price>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    public Task<Price> GetById(Guid Id);
}
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
