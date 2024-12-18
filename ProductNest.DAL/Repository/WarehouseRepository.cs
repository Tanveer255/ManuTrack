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
public class WarehouseRepository : Repository<Warehouse>, IWarehouseRepository
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<WarehouseRepository> _logger;
    public WarehouseRepository(IUnitOfWork unitOfWork, ILogger<WarehouseRepository> logger)
        : base(unitOfWork, logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }
    public async Task<Warehouse> GetById(Guid id)
    {
        Warehouse warehouse = new Warehouse();
        try
        {
            _logger.LogError("Getting bOMItem by Id");
            warehouse = (from ware in _unitOfWork.Context.Warehouse
                       where
                       ware.Id.Equals(id)
                       && ware.IsDeleted.Equals(false)

                       select new Warehouse
                       {
                           WarehouseId = ware.WarehouseId,
                           Zone = ware.Zone,
                           Aisle = ware.Aisle,
                           Location = ware.Location,
                           Shelf = ware.Shelf,
                           Rack = ware.Rack,
                           Bay = ware.Bay,
                           VariantId = ware.VariantId,
                           Variant = ware.Variant,
                           Inventory = ware.Inventory,
                       }).FirstOrDefault();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message, ex.InnerException, ex.InnerException != null ? ex.InnerException.Message : string.Empty);
            throw new Exception(ex.Message, ex.InnerException);
        }
        _logger.LogError("Returning warehouse :" + warehouse);
        return await Task.FromResult(warehouse);
    }
}
