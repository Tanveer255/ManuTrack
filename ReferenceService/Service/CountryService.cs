using Microsoft.EntityFrameworkCore;
using ReferenceService.Entity;
using ReferenceService.Repository;

namespace ReferenceService.Service;

public interface ICountryService:ICrudService<Country>
{
  public Task <List<Country>> GetAllDataAsync();
}

public class CountryService(
    IUnitOfWork unitOfWork,
    ICountryRepository countryRepository
    ): CrudService<Country>(countryRepository, unitOfWork), ICountryService
{
    private readonly ICountryRepository _countryRepository = countryRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<List<Country>> GetAllDataAsync()
    {
        return await _unitOfWork.Context.Countries.ToListAsync();
    }
}
