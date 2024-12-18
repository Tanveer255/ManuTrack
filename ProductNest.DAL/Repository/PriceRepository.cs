﻿using Microsoft.Extensions.Logging;
using ProductNest.DAL.Interface;
using ProductNest.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductNest.DAL.Repository;

public class PriceRepository : Repository<Price>, IPriceRepository
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<PriceRepository> _logger;
    public PriceRepository(IUnitOfWork unitOfWork, ILogger<PriceRepository> logger)
        : base(unitOfWork, logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }
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