using Microsoft.AspNetCore.Http;
using ProductNest.BLL.Interface;
using ProductNest.DAL.Interface;
using ProductNest.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductNest.BLL.Service;
public class PriceService : CrudService<Price>, IPriceService
{
    private readonly IPriceRepository _priceRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly HttpContext _httpContext;
    public PriceService(IPriceRepository priceRepository,
         IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        : base(priceRepository, unitOfWork)
    {
        _priceRepository = priceRepository;
        _unitOfWork = unitOfWork;
        _httpContext = httpContextAccessor.HttpContext;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<Price> GetById(Guid id)
    {
        var result = await _priceRepository.GetById(id);
        return result;
    }
}
