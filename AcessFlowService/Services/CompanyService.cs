using Infrastructure.Common;

namespace AcessFlowService.Services;

public interface ICompanyService : ICrudService<Company>
{
    public Task<ApiResponse<Company>> GetCompanyByIdAsync(Guid id);
    public Task<ApiResponse<IEnumerable<Company>>> GetAllCompaniesAsync();
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

    public async Task<ApiResponse<IEnumerable<Company>>> GetAllCompaniesAsync()
    {
        try
        {
            var companies = await _companyRepository.GetAllCompanies();
            if (companies == null || !companies.Any())
            {
                return ApiResponse<IEnumerable<Company>>.FailResponse("No companies found");
            }
            return ApiResponse<IEnumerable<Company>>.SuccessResponse(companies, "Companies found Sucessfully");
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "Error occurred while fetching all companies");
            return ApiResponse<IEnumerable<Company>>.FailResponse("Error occurred while fetching all companies");
        }

    }

    public async Task<ApiResponse<Company>> GetCompanyByIdAsync(Guid id)
    {
        try
        {
            var existedCompany = await _companyRepository.Get(id);
            if (existedCompany == null)
            {
                return ApiResponse<Company>.FailResponse("Company not found");
            }

            return ApiResponse<Company>.SuccessResponse(existedCompany, "Company found");
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "Error occurred while fetching company with id {Id}", id);
            return ApiResponse<Company>.FailResponse("Error occurred while fetching company");
        }

    }

    public async Task<ApiResponse<Company>> CreateAsync(Company company)
    {
        try
        {
            if (company.Id == Guid.Empty)
            {
                await _companyRepository.Add(company);
                return ApiResponse<Company>.SuccessResponse(company, "Company sucessfully created");
            }
            await _companyRepository.Update(company);
            _unitOfWork.Commit();
            return ApiResponse<Company>.SuccessResponse(company, "Company sucessfully updated");
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "Error occurred while creating company");
            return ApiResponse<Company>.FailResponse("Error occurred while creating company");
        }
    }

}
