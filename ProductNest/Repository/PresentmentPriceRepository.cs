namespace ProductNestService.Repository;
public interface IPresentmentPriceRepository : IRepository<PresentmentPrice>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<PresentmentPrice> GetById(Guid id);
}

public class PresentmentPriceRepository(
    IUnitOfWork unitOfWork,
    ILogger<PresentmentPriceRepository> logger
    ) : Repository<PresentmentPrice>(unitOfWork, logger), IPresentmentPriceRepository
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ILogger<PresentmentPriceRepository> _logger = logger;
    public async Task<PresentmentPrice> GetById(Guid id)
    {
        PresentmentPrice presentmentPrice = new PresentmentPrice();
        try
        {
            _logger.LogError("Getting PresentmentPrice by Id");
            presentmentPrice = (from bom in _unitOfWork.Context.PresentmentPrices
                         where
                         bom.Id.Equals(id)
                         && bom.IsDeleted.Equals(false)

                         select new PresentmentPrice
                         {
                             PredentPriceId = bom.PredentPriceId,
                             Price = bom.Price,
                             CompareAtPrice = bom.CompareAtPrice,
                         }).FirstOrDefault();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message, ex.InnerException, ex.InnerException != null ? ex.InnerException.Message : string.Empty);
            throw new Exception(ex.Message, ex.InnerException);
        }
        _logger.LogError("Returning imageFile :" + presentmentPrice);
        return await Task.FromResult(presentmentPrice);
    }
}
