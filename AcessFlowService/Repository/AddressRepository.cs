using AcessFlowService.Entity.Entity;

namespace AcessFlowService.Repository;

public interface IAddressRepository : IRepository<Address>
{
    Task<IEnumerable<Address>> GetAddressesByCompanyIdAsync(Guid companyId);
}

internal sealed class AddressRepository(
    IUnitOfWork unitOfWork,
        ILogger<AddressRepository> logger
    ) : Repository<Address>(unitOfWork, logger), IAddressRepository
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ILogger<AddressRepository> _logger = logger;


    public async Task<IEnumerable<Address>> GetAddressesByCompanyIdAsync(Guid companyId)
    {
        return await _unitOfWork.Context.Set<Address>()
            .Where(a => a.CompanyId == companyId)
            .ToListAsync();
    }
}
