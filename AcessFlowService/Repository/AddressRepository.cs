using AcessFlowService.Entity.Entity;

namespace AcessFlowService.Repository;

public interface IAddressRepository : IRepository<Address>
{
    Task<IEnumerable<Address>> GetAddressesByCompanyIdAsync(Guid companyId);
}

internal sealed class AddressRepository : Repository<Address>, IAddressRepository
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<AddressRepository> _logger;
    private readonly DbContext _context; // Add DbContext

    public AddressRepository(IUnitOfWork unitOfWork, ILogger<AddressRepository> logger, DbContext context) //Add DbContext
        : base(unitOfWork, logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
        _context = context; //Initialize DbContext
    }

    public async Task<IEnumerable<Address>> GetAddressesByCompanyIdAsync(Guid companyId)
    {
        return await _context.Set<Address>()
            .Where(a => a.CompanyId == companyId)
            .ToListAsync();
    }
}
