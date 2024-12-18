using Microsoft.Extensions.Logging;
using ProductNest.DAL.Interface;
using ProductNest.Entity;
using ProductNest.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductNest.DAL.Repository;
public class UnitOfMeasureRepository : Repository<UnitOfMeasure>, IUnitOfMeasureRepository
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<UnitOfMeasureRepository> _logger;
    public UnitOfMeasureRepository(IUnitOfWork unitOfWork, ILogger<UnitOfMeasureRepository> logger)
        : base(unitOfWork, logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }
    public async Task<UnitOfMeasure> GetById(string code)
    {
        var unitOfMeasure = new UnitOfMeasure();
        try
        {
            _logger.LogError("Getting bOMItem by Id");
            unitOfMeasure = (from uom in _unitOfWork.Context.UnitOfMeasures
                       where
                       uom.Code.Equals(code)
                       select new UnitOfMeasure
                       {
                           Code = uom.Code,
                           Name = uom.Name,
                       }).FirstOrDefault();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message, ex.InnerException, ex.InnerException != null ? ex.InnerException.Message : string.Empty);
            throw new Exception(ex.Message, ex.InnerException);
        }
        _logger.LogError("Returning unitOfMeasure :" + unitOfMeasure);
        return await Task.FromResult(unitOfMeasure);
    }
}
