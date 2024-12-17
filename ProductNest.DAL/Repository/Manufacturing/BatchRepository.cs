using Microsoft.Extensions.Logging;
using ProductNest.DAL.Interface;
using ProductNest.DAL.Interface.Manufacturing;
using ProductNest.Entity;
using ProductNest.Entity.Manufacturing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductNest.DAL.Repository.Manufacturing;

public class BatchRepository : Repository<Batch>, IBatchRepository
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<BatchRepository> _logger;
    public BatchRepository(IUnitOfWork unitOfWork, ILogger<BatchRepository> logger)
        : base(unitOfWork, logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }
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
