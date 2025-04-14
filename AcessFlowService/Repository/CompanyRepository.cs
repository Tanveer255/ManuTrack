namespace AcessFlowService.Repository;

public interface ICompanyRepository : IRepository<Company>
{
    Task<IEnumerable<Company>> GetAllCompanies();
    Task<Company> Get(Guid id);
}

internal sealed class CompanyRepository(
    IUnitOfWork unitOfWork,
    ILogger<CompanyRepository> logger
    ) : Repository<Company>(unitOfWork,logger), ICompanyRepository
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ILogger<CompanyRepository> _logger= logger;

    public async Task<IEnumerable<Company>> GetAllCompanies()
    {
        return await _unitOfWork.Context.Companies // using _context
            .Include(c => c.PrimaryAddress)
            .Include(c => c.SecondaryAddress)
            .Include(c => c.InvoiceAddress)
            .Include(c => c.OtherAddresses)
            .ToListAsync();
    }

    public async Task<Company> Get(Guid id)
    {
        return await _unitOfWork.Context.Companies // using _context
            .Where(c => c.Id == id)
            .Include(c => c.PrimaryAddress)
            .Include(c => c.SecondaryAddress)
            .Include(c => c.InvoiceAddress)
            .Include(c => c.OtherAddresses)
            .FirstOrDefaultAsync();
    }
}