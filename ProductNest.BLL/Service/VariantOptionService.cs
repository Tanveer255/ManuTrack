using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ProductNest.BLL.Interface;
using ProductNest.DAL.Interface;
using ProductNest.Entity;
using ProductNest.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductNest.BLL.Service;
public class VariantOptionService : CrudService<VariantOption>, IVariantOptionService
{
    private readonly IVariantOptionRepository _variantOptionRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly HttpContext _httpContext;
    public VariantOptionService(IVariantOptionRepository variantOptionRepository,
         IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        : base(variantOptionRepository, unitOfWork)
    {
        _variantOptionRepository = variantOptionRepository;
        _unitOfWork = unitOfWork;
        _httpContext = httpContextAccessor.HttpContext;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<VariantOption> GetById(Guid id)
    {
        var result = await _variantOptionRepository.GetById(id);
        return result;
    }
    public async Task<List<VariantOption>> GetAllDataAsync()
    {
        var result = await _unitOfWork.Context.VariantOption.ToListAsync();
        return result;
    }
}
