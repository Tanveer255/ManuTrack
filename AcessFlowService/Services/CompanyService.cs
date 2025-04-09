using JwtAuthentication.Common;

namespace AcessFlowService.Services;

public interface ICompanyService : ICrudService<Company>
{
    Task<IEnumerable<Company>> GetCompaniesWithAddressesAsync();
    Task<Company> GetCompanyWithAddressesAsync(Guid id);
    public  Task<Company> CreateAsync(Company company);
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

    public async Task<ApiResponse<Company>> CreateAsync(Company company)
    {
        if (company == null)
        {
            return ApiResponse<Company>.FailResponse("Company is not created");
        }
        await _companyRepository.Add(company);
        _unitOfWork.Commit();
        return ApiResponse<Company>.SuccessResponse(company,"Company sucessfully created");
    }

}
