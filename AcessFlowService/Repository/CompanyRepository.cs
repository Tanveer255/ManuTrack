using AcessFlowService.Entity.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcessFlowService.Repository;

public interface ICompanyRepository : IRepository<Company>
{
    Task<IEnumerable<Company>> GetCompaniesWithAddressesAsync();
    Task<Company> GetCompanyWithAddressesAsync(Guid id);
}

internal sealed class CompanyRepository : Repository<Company>, ICompanyRepository
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<CompanyRepository> _logger;
    private readonly AcessFlowServiceDbContext _context; // Added context

    public CompanyRepository(IUnitOfWork unitOfWork, ILogger<CompanyRepository> logger, AcessFlowServiceDbContext context) // Corrected context type
        : base(unitOfWork, logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
        _context = context; // assigned context
    }

    public async Task<IEnumerable<Company>> GetCompaniesWithAddressesAsync()
    {
        return await _context.Companies // using _context
            .Include(c => c.PrimaryAddress)
            .Include(c => c.SecondaryAddress)
            .Include(c => c.InvoiceAddress)
            .Include(c => c.OtherAddresses)
            .ToListAsync();
    }

    public async Task<Company> GetCompanyWithAddressesAsync(Guid id)
    {
        return await _context.Companies // using _context
            .Where(c => c.Id == id)
            .Include(c => c.PrimaryAddress)
            .Include(c => c.SecondaryAddress)
            .Include(c => c.InvoiceAddress)
            .Include(c => c.OtherAddresses)
            .FirstOrDefaultAsync();
    }
}