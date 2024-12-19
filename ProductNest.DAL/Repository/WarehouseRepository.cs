using Microsoft.EntityFrameworkCore;
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
    public async Task<Warehouse> GetByIdAsync(Guid id)
    {
        try
        {
            _logger.LogInformation("Getting Warehouse by Id: {Id}", id);

            var warehouse = await (from ware in _unitOfWork.Context.Warehouse
                                   where ware.Id == id && !ware.IsDeleted
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
                                   }).FirstOrDefaultAsync();

            if (warehouse == null)
            {
                _logger.LogWarning("Warehouse with Id: {Id} not found.", id);
            }
            else
            {
                _logger.LogInformation("Returning Warehouse: {Warehouse}", warehouse);
            }

            return warehouse;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while fetching Warehouse with Id: {Id}", id);
            throw; // Re-throw the original exception to preserve the stack trace
        }
    }

}
