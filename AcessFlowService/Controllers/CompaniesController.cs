namespace AcessFlowService.Controllers;
[ApiController]
[Route("api/companies")]
public class CompaniesController(
    ICompanyService companyService,
        ILogger<CompaniesController> logger
    ) : ControllerBase
{
    private readonly ICompanyService _companyService = companyService;
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
            var company = await _companyService.GetCompanyByIdAsync(id);

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

    [HttpPost(nameof(CreateCompany))]
    public async Task<ActionResult<Company>> CreateCompany(Company company)
    {
        try
        {
            var result = await _companyService.CreateAsync(company);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "Error occurred while creating company");
            return BadRequest("Error occurred while creating company");
        }
    }
}
