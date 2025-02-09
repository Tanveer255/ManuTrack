namespace ProductNest.BLL.Service.Manufacturing;

public class BatchService(
    IBatchRepository batchRepository,
         IUnitOfWork unitOfWork,
         IHttpContextAccessor httpContextAccessor
    ) : CrudService<Batch>(batchRepository, unitOfWork), IBatchService
{
    private readonly IBatchRepository _batchRepository = batchRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly HttpContext _httpContext = httpContextAccessor.HttpContext;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="productId"></param>
    /// <returns></returns>
    public async Task<Batch> GetById(Guid productId)
    {
        var batches = await _batchRepository.GetById(productId);
        return batches;
    }
    public async Task<List<Batch>> GetAllDataAsync()
    {
        var batches = await _unitOfWork.Context.Batchs.ToListAsync();
        return batches;
    }
}
