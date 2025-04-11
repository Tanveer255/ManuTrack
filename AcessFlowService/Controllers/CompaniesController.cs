namespace AcessFlowService.Controllers;
[ApiController]
[Route("api/companies")]
public class CompaniesController(
    ICompanyService companyService,
    ICompanyRepository companyRepository,
        IAddressRepository addressService,
        IUnitOfWork unitOfWork
    ) : ControllerBase
{
    private readonly ICompanyService _companyService = companyService;
    private readonly ICompanyRepository _companyRepository = companyRepository;
    private readonly IAddressRepository _addressService = addressService;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;


    [HttpGet(nameof(GetCompanies))]
    public async Task<ActionResult<IEnumerable<Company>>> GetCompanies()
    {
        var companies = await _companyService.GetCompaniesWithAddressesAsync();
        return Ok(companies);
    }

    [HttpGet(nameof(GetCompany))]
    public async Task<ActionResult<Company>> GetCompany(Guid id)
    {
        var company = await _companyService.GetCompanyAsync(id);

        if (company.Success)
        {
            return Ok(company);
        }

        return BadRequest(company.Message);
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
