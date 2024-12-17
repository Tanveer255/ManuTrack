using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ProductNest.BLL.Interface;
using ProductNest.DAL.Interface;
using ProductNest.DAL.Repository;
using ProductNest.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductNest.BLL.Service;

public class BOMItemService : CrudService<BOMItem>, IBOMItemService
{
    private readonly IBOMItemRepository _bOMItemRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly HttpContext _httpContext;
    public BOMItemService(IBOMItemRepository bOMItemRepository,
         IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        : base(bOMItemRepository, unitOfWork)
    {
        _bOMItemRepository = bOMItemRepository;
        _unitOfWork = unitOfWork;
        _httpContext = httpContextAccessor.HttpContext;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<BOMItem> GetById(Guid id)
    {
        var result = await _bOMItemRepository.GetById(id);
        return result;
    }
    public async Task<List<BOMItem>> GetAllDataAsync()
    {
        var result = await _unitOfWork.Context.BOMItems.ToListAsync();
        return result;
    }
}
