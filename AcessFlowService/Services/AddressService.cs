using AcessFlowService.Services;
using AcessFlowService.Entity.Entity;

namespace AcessFlowService.Services;

public interface IAddressService : ICrudService<Address>
{
    Task<IEnumerable<Address>> GetAddressesByCompanyIdAsync(Guid companyId);
}

internal sealed class AddressService : CrudService<Address>, IAddressService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAddressRepository _addressRepository;

    public AddressService(IUnitOfWork unitOfWork, IAddressRepository addressRepository)
        : base(addressRepository, unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _addressRepository = addressRepository;
    }

    public async Task<IEnumerable<Address>> GetAddressesByCompanyIdAsync(Guid companyId)
    {
        return await _addressRepository.GetAddressesByCompanyIdAsync(companyId);
    }
}