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

internal sealed class CompanyService : CrudService<Company>, ICompanyService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICompanyRepository _companyRepository;

    public CompanyService(IUnitOfWork unitOfWork, ICompanyRepository companyRepository)
        : base(companyRepository, unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _companyRepository = companyRepository;
    }

    public async Task<IEnumerable<Company>> GetCompaniesWithAddressesAsync()
    {
        return await _companyRepository.GetCompaniesWithAddressesAsync();
    }

    public async Task<Company> GetCompanyWithAddressesAsync(Guid id)
    {
        return await _companyRepository.GetCompanyWithAddressesAsync(id);
    }
}
