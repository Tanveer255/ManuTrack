using AcessFlowService.Entity.Entity;
using AcessFlowService.Services;

namespace AcessFlowService.Controllers;

[ApiController]
[Route("api/companies")]
public class CompaniesController : ControllerBase
{
    private readonly ICompanyService _companyService;
    private readonly IAddressService _addressService;

    public CompaniesController(ICompanyService companyService, IAddressService addressService)
    {
        _companyService = companyService;
        _addressService = addressService;
    }

    [HttpGet(nameof(GetCompanies))]
    public async Task<ActionResult<IEnumerable<Company>>> GetCompanies()
    {
        var companies = await _companyService.GetCompaniesWithAddressesAsync();
        return Ok(companies);
    }

    [HttpGet(nameof(GetCompany))]
    public async Task<ActionResult<Company>> GetCompany(Guid id)
    {
        var company = await _companyService.GetCompanyWithAddressesAsync(id);

        if (company == null)
        {
            return NotFound();
        }

        return Ok(company);
    }

    [HttpPost(nameof(PostCompany))]
    public async Task<ActionResult<Company>> PostCompany(Company company)
    {
        await _companyService.Add(company);

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
        return NoContent();
    }

    //[HttpDelete("{id}")]
    //public async Task<IActionResult> DeleteCompany(Guid id)
    //{
    //    await _companyService.Delete(id);
    //    return NoContent();
    //}

    [HttpGet(nameof(GetAddressesByCompany))]
    public async Task<ActionResult<IEnumerable<Address>>> GetAddressesByCompany(Guid companyId)
    {
        var addresses = await _addressService.GetAddressesByCompanyIdAsync(companyId);
        return Ok(addresses);
    }

    [HttpPost(nameof(PostAddress))]
    public async Task<ActionResult<Address>> PostAddress(Guid companyId, Address address)
    {
        address.CompanyId = companyId;
        await _addressService.Add(address);
        return CreatedAtAction(nameof(GetAddressesByCompany), new { companyId = companyId }, address);
    }
}
