namespace ProductNestService.Enum;

public enum ProductStatus
{
    Active
}
public enum StockStatus
{
    Available,        // Stock is available for use
    OutOfStock,       // No stock available
    Reserved,         // Stock is reserved for orders
    Quarantined,      // Stock is under quarantine
    Expired,          // Stock has expired
    Rejected,         // Stock is rejected or not usable
    PendingInspection // Stock pending quality inspection
}
