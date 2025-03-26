using AcessFlowService.Entity.Entity;

namespace AcessFlowService.Repository;

public interface IAddressRepository : IRepository<Entity.Entity.Address>
{
    Task Add(Entity.Entity.Address address);
    Task<IEnumerable<Entity.Entity.Address>> GetAddressesByCompanyIdAsync(Guid companyId);
}

internal sealed class AddressRepository(
    IUnitOfWork unitOfWork,
        ILogger<AddressRepository> logger
    ) : Repository<Entity.Entity.Address>(unitOfWork, logger), IAddressRepository
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ILogger<AddressRepository> _logger = logger;


    public async Task<IEnumerable<Entity.Entity.Address>> GetAddressesByCompanyIdAsync(Guid companyId)
    {
        return await _unitOfWork.Context.Set<Entity.Entity.Address>()
            .Where(a => a.CompanyId == companyId)
            .ToListAsync();
    }
}
