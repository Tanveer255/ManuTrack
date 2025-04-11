namespace AcessFlowService.Controllers;
[ApiController]
[Route("api/companies")]
public class CompaniesController(
    ICompanyService companyService,
    ICompanyRepository companyRepository,
        IAddressRepository addressService,
        IUnitOfWork unitOfWork,
        ILogger<CompaniesController> logger
    ) : ControllerBase
{
    private readonly ICompanyService _companyService = companyService;
    private readonly ICompanyRepository _companyRepository = companyRepository;
    private readonly IAddressRepository _addressService = addressService;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ILogger<CompaniesController> _logger = logger;


    [HttpGet(nameof(GetAllCompanies))]
    public async Task<ActionResult<IEnumerable<Company>>> GetAllCompanies()
    {
        try
        {
            var companies = await _companyService.GetAllCompaniesAsync();
            if (companies.Success)
            {
                return Ok(companies);
            }
            return NotFound("No companies found");
        }
        catch (Exception Exception)
        {
           _logger.LogError(Exception, "Error occurred while fetching all companies");
            return BadRequest("Error occurred while fetching all companies");
        }
        
    }

    [HttpGet(nameof(GetCompany))]
    public async Task<ActionResult<Company>> GetCompany(Guid id)
    {
        try
        {
            var company = await _companyService.GetCompanyAsync(id);

            if (company.Success)
            {
                return Ok(company);
            }

            return BadRequest(company.Message);

        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "Error occurred while fetching company with id {Id}", id);
            return BadRequest("Error occurred while fetching company");
        }
        
    }

    [HttpPost(nameof(PostCompany))]
    public async Task<ActionResult<Company>> PostCompany(Company company)
    {
        await _companyService.Add(company);
        _unitOfWork.Commit();
        return CreatedAtAction(nameof(GetCompany), new { id = company.Id }, company);
    }

    [HttpPut(nameof(PutCompany))]
    public async Task<IActionResult> PutCompany(Guid id, Company company)
    {
        if (id != company.Id)
        {
            return BadRequest();
        }

        await _companyService.Update(company);
        _unitOfWork.Commit();
        return Ok(company);
    }

    [HttpGet(nameof(GetAddressesByCompany))]
    public async Task<ActionResult<IEnumerable<Entity.Entity.Address>>> GetAddressesByCompany(Guid companyId)
    {
        var addresses = await _addressService.GetAddressesByCompanyIdAsync(companyId);
        return Ok(addresses);
    }

    [HttpPost(nameof(PostAddress))]
    public async Task<ActionResult<Entity.Entity.Address>> PostAddress(Guid companyId, Entity.Entity.Address address)
    {
        address.CompanyId = companyId;
        await _addressService.Add(address);
        _unitOfWork.Commit();
        return CreatedAtAction(nameof(GetAddressesByCompany), new { companyId = companyId }, address);
    }
}
