using AcessFlowService.Services;
using AcessFlowService.Entity.Entity;

using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace AcessFlowService.Services;

public interface ICompanyService : ICrudService<Company>
{
    Task<IEnumerable<Company>> GetCompaniesWithAddressesAsync();
    Task<Company> GetCompanyWithAddressesAsync(Guid id);
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
}
