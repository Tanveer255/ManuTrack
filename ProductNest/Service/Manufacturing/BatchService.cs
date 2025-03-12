namespace ProductNestService.Service.Manufacturing;
public interface IBatchService : ICrudService<Batch>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<Batch> GetById(Guid id);
    public Task<List<Batch>> GetAllDataAsync();
    public Task<Batch> AddUpdate(Batch batch);
}

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
    public async Task<Batch> AddUpdate(Batch batch) {
        var result = await BatchExist(batch.Id);
        if (result)
        {
            await _batchRepository.Add(batch);
            _unitOfWork.Commit();
            return batch;
        }
        await _batchRepository.Update(batch);
        _unitOfWork.Commit();
        return batch;
    }
    public async Task<bool> BatchExist(Guid id)
    {
        var result = await _unitOfWork.Context.Batchs.FindAsync(id);
        if (result != null)
            return true;
        return false;
    }
}
