

namespace ProductNest.DAL.Repository.Manufacturing;

public class BatchRepository(IUnitOfWork unitOfWork,
    ILogger<BatchRepository> logger
    ) : Repository<Batch>(unitOfWork, logger), IBatchRepository
{
    private readonly IUnitOfWork _unitOfWork =unitOfWork;
    private readonly ILogger<BatchRepository> _logger = logger;
    public async Task<Batch> GetById(Guid Id)
    {
        Batch batch = new Batch();
        try
        {
            _logger.LogError("Getting batchs by Id");
            batch = (from batc in _unitOfWork.Context.Batchs
                       where
                       batc.Id.Equals(Id)
                       && batc.Status == Enum.ProductStatus.Active.ToString()
                       && batc.IsDeleted.Equals(false)

                       select new Batch
                       {
                           BatchId = batc.BatchId,
                           CancellationReason = batc.CancellationReason,
                           ManufacturedQuantity = batc.ManufacturedQuantity,
                           ExpectedStartDate = batc.ExpectedStartDate,
                           ActualStartDate = batc.ActualStartDate,
                           ExpectedFinishDate = batc.ExpectedFinishDate,
                           ActualFinishDate = batc.ActualFinishDate,
                           TotalWorkingDays = batc.TotalWorkingDays,
                           Status = batc.Status,
                           StockHandlingProcedure = batc.StockHandlingProcedure,
                           ProgressTracking = batc.ProgressTracking,
                           CompletedQuantity = batc.CompletedQuantity,
                           IsCompleted = batc.IsCompleted,
                       }).FirstOrDefault();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message, ex.InnerException, ex.InnerException != null ? ex.InnerException.Message : string.Empty);
            throw new Exception(ex.Message, ex.InnerException);
        }
        _logger.LogError("Returning products :" + batch);
        return await Task.FromResult(batch);
    }
}
