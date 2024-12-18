using Microsoft.Extensions.Logging;
using ProductNest.DAL.Interface;
using ProductNest.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductNest.DAL.Repository;

public class InventoryRepository : Repository<Inventory>, IInventoryRepository
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<InventoryRepository> _logger;
    public InventoryRepository(IUnitOfWork unitOfWork, ILogger<InventoryRepository> logger)
        : base(unitOfWork, logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }
    public async Task<Inventory> GetById(Guid id)
    {
        Inventory inventory = new Inventory();
        try
        {
            _logger.LogError("Getting inventory by Id");
            inventory = (from inven in _unitOfWork.Context.Inventorys
                         where
                         inven.Id.Equals(id)
                         && inven.IsDeleted.Equals(false)

                         select new Inventory
                         {
                             InventoryId = inven.InventoryId,
                             ProductId = inven.ProductId,
                             ProductName = inven.ProductName,
                             Status = inven.Status,
                             StorageLocation = inven.StorageLocation,
                             Quantity = inven.Quantity,
                             AvailableQuantity = inven.AvailableQuantity,
                             ReservedQuantity = inven.ReservedQuantity,
                             QuarantinedQuantity = inven.QuarantinedQuantity,
                             RejectedQuantity = inven.RejectedQuantity,
                             ExpiredQuantity = inven.ExpiredQuantity,
                             WarehouseId = inven.WarehouseId,
                             PriceId = inven.PriceId,
                             Price = inven.Price,
                         }).FirstOrDefault();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message, ex.InnerException, ex.InnerException != null ? ex.InnerException.Message : string.Empty);
            throw new Exception(ex.Message, ex.InnerException);
        }
        _logger.LogError("Returning inventory :" + inventory);
        return await Task.FromResult(inventory);
    }
}
