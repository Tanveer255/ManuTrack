﻿using Microsoft.Extensions.Logging;
using ProductNest.DAL.Interface;
using ProductNest.Entity;
using ProductNest.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductNest.DAL.Repository;
public class VariantOptionRepository : Repository<VariantOption>, IVariantOptionRepository
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<VariantOptionRepository> _logger;
    public VariantOptionRepository(IUnitOfWork unitOfWork, ILogger<VariantOptionRepository> logger)
        : base(unitOfWork, logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }
    public async Task<VariantOption> GetById(Guid id)
    {
        VariantOption variantOption = new VariantOption();
        try
        {
            _logger.LogError("Getting variantOption by Id");
            variantOption = (from varop in _unitOfWork.Context.VariantOption
                       where
                       varop.Id.Equals(id)
                       && varop.IsDeleted.Equals(false)

                       select new VariantOption
                       {
                           VariantOptionId = varop.VariantOptionId,
                           ProductId = varop.ProductId,
                           Name = varop.Name,
                           Position = varop.Position,
                           Values = varop.Values,
                       }).FirstOrDefault();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message, ex.InnerException, ex.InnerException != null ? ex.InnerException.Message : string.Empty);
            throw new Exception(ex.Message, ex.InnerException);
        }
        _logger.LogError("Returning variantOption :" + variantOption);
        return await Task.FromResult(variantOption);
    }
}
