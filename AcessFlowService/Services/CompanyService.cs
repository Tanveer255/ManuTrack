namespace AcessFlowService.Services;

public interface ICompanyService : ICrudService<Company>
{
    Task<IEnumerable<Company>> GetCompaniesWithAddressesAsync();
    Task<Company> GetCompanyWithAddressesAsync(Guid id);
    //Company create(Company company);
}

internal sealed class CompanyService(
    IUnitOfWork unitOfWork,
    ICompanyRepository companyRepository
    ) : CrudService<Company>(companyRepository, unitOfWork), ICompanyService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ICompanyRepository _companyRepository = companyRepository;

    public async Task<IEnumerable<Company>> GetCompaniesWithAddressesAsync()
    {
        return await _companyRepository.GetCompaniesWithAddressesAsync();
    }

    public async Task<Company> GetCompanyWithAddressesAsync(Guid id)
    {
        return await _companyRepository.GetCompanyWithAddressesAsync(id);
    }

    public async Task<Company> CreateAsync(Company company)
    {
        await _companyRepository.Add(company);
        _unitOfWork.Commit();
        return company;
    }

}
