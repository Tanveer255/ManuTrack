namespace ProductNest.DAL.Repository;
public class VariantOptionRepository(
    IUnitOfWork unitOfWork,
    ILogger<VariantOptionRepository> logger
    ) : Repository<VariantOption>(unitOfWork, logger), IVariantOptionRepository
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ILogger<VariantOptionRepository> _logger = logger;
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
