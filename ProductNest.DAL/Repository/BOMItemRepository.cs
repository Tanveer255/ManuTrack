﻿using Microsoft.Extensions.Logging;
using ProductNest.DAL.Interface;
using ProductNest.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductNest.DAL.Repository;

public class BOMItemRepository : Repository<BOMItem>, IBOMItemRepository
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<BOMItemRepository> _logger;
    public BOMItemRepository(IUnitOfWork unitOfWork, ILogger<BOMItemRepository> logger)
        : base(unitOfWork, logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }
    public async Task<BOMItem> GetById(Guid id)
    {
        BOMItem bOMItem = new BOMItem();
        try
        {
            _logger.LogError("Getting bOMItem by Id");
            bOMItem = (from bom in _unitOfWork.Context.BOMItems
                       where
                       bom.Id.Equals(id)
                       && bom.IsDeleted.Equals(false)

                       select new BOMItem
                       {
                           BomItemId = bom.BomItemId,
                           MaterialName = bom.MaterialName,
                           InventoryId = bom.InventoryId,
                           UnitOfMeasure = bom.UnitOfMeasure,
                           ProductId = bom.ProductId,
                           Version = bom.Version,
                       }).FirstOrDefault();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message, ex.InnerException, ex.InnerException != null ? ex.InnerException.Message : string.Empty);
            throw new Exception(ex.Message, ex.InnerException);
        }
        _logger.LogError("Returning bOMItem :" + bOMItem);
        return await Task.FromResult(bOMItem);
    }
}