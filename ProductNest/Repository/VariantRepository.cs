namespace ProductNest.Repository;
public interface IVariantRepository : IRepository<Variant>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<Variant> GetById(Guid id);
}
public class VariantRepository(
    IUnitOfWork unitOfWork,
    ILogger<VariantRepository> logger
    ) : Repository<Variant>(unitOfWork,logger), IVariantRepository
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ILogger<VariantRepository> _logger = logger;
    public async Task<Variant> GetById(Guid id)
    {
        Variant variant = new Variant();
        try
        {
            _logger.LogError("Getting variant by Id");
            variant = (from vari in _unitOfWork.Context.Variants
                       where
                       vari.Id.Equals(id)
                       && vari.IsDeleted.Equals(false)

                       select new Variant
                       {
                           Title = vari.Title,
                           BodyHtml = vari.BodyHtml,
                           Vendor = vari.Vendor,
                           ProductType = vari.ProductType,
                           Tags = vari.Tags,
                           Status = vari.Status,
                           AdminGraphqlApiId = vari.AdminGraphqlApiId,
                           VariantId = vari.VariantId,
                           ParentProductId = vari.ParentProductId,
                           Position = vari.Position,
                           InventoryPolicy = vari.InventoryPolicy,
                           CompareAtPrice = vari.CompareAtPrice,
                           Option1 = vari.Option1,
                           Option2 = vari.Option2,
                           Option3 = vari.Option3,
                           Taxable = vari.Taxable,
                           Barcode = vari.Barcode,
                           FulfillmentService = vari.FulfillmentService,
                           Grams = vari.Grams,
                           InventoryManagement = vari.InventoryManagement,
                           RequiresShipping = vari.RequiresShipping,
                           Sku = vari.Sku,
                           Weight = vari.Weight,
                           WeightUnit = vari.WeightUnit,
                           InventoryId = vari.InventoryId,
                           InventoryQuantity = vari.InventoryQuantity,
                           OldInventoryQuantity = vari.OldInventoryQuantity,
                           PresentmentPrices = vari.PresentmentPrices,
                           ImageId = vari.ImageId,
                       }).FirstOrDefault();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message, ex.InnerException, ex.InnerException != null ? ex.InnerException.Message : string.Empty);
            throw new Exception(ex.Message, ex.InnerException);
        }
        _logger.LogError("Returning variant :" + variant);
        return await Task.FromResult(variant);
    }
}
