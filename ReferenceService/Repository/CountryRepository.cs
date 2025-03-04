using ReferenceService.Entity;

namespace ReferenceService.Repository;

public interface ICountryRepository:IRepository<Country>
{
}
public class CountryRepository(
    IUnitOfWork unitOfWork,
    ILogger<CountryRepository> logger
    ) :Repository<Country>(unitOfWork, logger), ICountryRepository
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ILogger<CountryRepository> _logger = logger;
}
