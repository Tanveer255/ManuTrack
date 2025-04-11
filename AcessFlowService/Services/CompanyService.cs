using Infrastructure.Common;

namespace AcessFlowService.Services;

public interface ICompanyService : ICrudService<Company>
{
    public Task<ApiResponse<Company>> GetCompanyAsync(Guid id);
    public Task<IEnumerable<Company>> GetCompaniesWithAddressesAsync();
    public Task<ApiResponse<Company>> CreateAsync(Company company);
}

internal sealed class CompanyService(
    IUnitOfWork unitOfWork,
    ICompanyRepository companyRepository,
    ILogger<CompanyService> logger
    ) : CrudService<Company>(companyRepository, unitOfWork), ICompanyService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ICompanyRepository _companyRepository = companyRepository;
    private readonly ILogger<CompanyService> _logger = logger;

    public async Task<IEnumerable<Company>> GetCompaniesWithAddressesAsync()
    {
        return await _companyRepository.GetCompaniesWithAddressesAsync();
    }

    public async Task<ApiResponse<Company>> GetCompanyAsync(Guid id)
    {
        try
        {
            var existedCompany = await _companyRepository.GetCompanyWithAddressesAsync(id);
            if (existedCompany == null)
            {
                return ApiResponse<Company>.FailResponse("Company not found");
            }
            var company = await _companyRepository.GetCompanyWithAddressesAsync(id);

            return ApiResponse<Company>.SuccessResponse(company, "Company found");
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "Error occurred while fetching company with id {Id}", id);
            return ApiResponse<Company>.FailResponse("Error occurred while fetching company");
        }
        
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
