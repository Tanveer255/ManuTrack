﻿namespace ProductNestService.Repository;
public interface IPriceRepository : IRepository<Price>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<Price> GetById(Guid id);
}

public class PriceRepository(
    IUnitOfWork unitOfWork,
    ILogger<PriceRepository> logger
    ) : Repository<Price>(unitOfWork, logger), IPriceRepository
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ILogger<PriceRepository> _logger = logger;
    public async Task<Price> GetById(Guid id)
    {
        Price price = new Price();
        try
        {
            _logger.LogError("Getting price by Id");
            price = (from pri in _unitOfWork.Context.Prices
                                where
                                pri.Id.Equals(id)
                                && pri.IsDeleted.Equals(false)

                                select new Price
                                {
                                    PriceId = pri.PriceId,
                                    Amount = pri.Amount,
                                    CurrencyCode = pri.CurrencyCode,
                                    ProductId = pri.ProductId,
                                    UnitPrice = pri.UnitPrice,
                                    SellingPrice = pri.SellingPrice,
                                }).FirstOrDefault();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message, ex.InnerException, ex.InnerException != null ? ex.InnerException.Message : string.Empty);
            throw new Exception(ex.Message, ex.InnerException);
        }
        _logger.LogError("Returning price :" + price);
        return await Task.FromResult(price);
    }
}