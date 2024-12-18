﻿using Microsoft.Extensions.Logging;
using ProductNest.DAL.Interface.Manufacturing;
using ProductNest.DAL.Interface;
using ProductNest.Entity.Manufacturing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductNest.DAL.Repository.Manufacturing;

public class CompletedPartRepository : Repository<CompletedPart>, ICompletedPartRepository
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<CompletedPartRepository> _logger;
    public CompletedPartRepository(IUnitOfWork unitOfWork, ILogger<CompletedPartRepository> logger)
        : base(unitOfWork, logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }
    public async Task<CompletedPart> GetById(Guid Id)
    {
        CompletedPart completedPart = new CompletedPart();
        try
        {
            _logger.LogError("Getting CompletedPart by Id");
            completedPart = (from cp in _unitOfWork.Context.CompletedParts
                     where
                     cp.Id.Equals(Id)
                     && cp.IsDeleted.Equals(false)

                     select new CompletedPart
                     {
                         Id = cp.Id,
                         CreatedAt = cp.CreatedAt,
                         UpdatedAt = cp.UpdatedAt,
                         IsDeleted = cp.IsDeleted,
                         BatchId = cp.BatchId,
                         Batch = cp.Batch,
                         CompletePartId = cp.CompletePartId,
                         DateCompleted = cp.DateCompleted,
                         PartCompleted = cp.PartCompleted,
                        
                     }).FirstOrDefault();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message, ex.InnerException, ex.InnerException != null ? ex.InnerException.Message : string.Empty);
            throw new Exception(ex.Message, ex.InnerException);
        }
        _logger.LogError("Returning CompletedPart :" + completedPart);
        return await Task.FromResult(completedPart);
    }
}