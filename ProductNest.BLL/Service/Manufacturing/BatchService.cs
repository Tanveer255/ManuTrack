using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ProductNest.BLL.Interface;
using ProductNest.BLL.Interface.Manufacturing;
using ProductNest.DAL.Interface;
using ProductNest.DAL.Interface.Manufacturing;
using ProductNest.DAL.Repository;
using ProductNest.Entity;
using ProductNest.Entity.Manufacturing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductNest.BLL.Service.Manufacturing;

public class BatchService : CrudService<Batch>, IBatchService
{
    private readonly IBatchRepository _batchRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly HttpContext _httpContext;
    public BatchService(IBatchRepository batchRepository,
         IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        : base(batchRepository, unitOfWork)
    {
        _batchRepository = batchRepository;
        _unitOfWork = unitOfWork;
        _httpContext = httpContextAccessor.HttpContext;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="productId"></param>
    /// <returns></returns>
    public async Task<Batch> GetById(Guid productId)
    {
        var batches = await _batchRepository.GetById(productId);
        return batches;
    }
    public async Task<List<Batch>> GetAllDataAsync()
    {
        var batches = await _unitOfWork.Context.Batchs.ToListAsync();
        return batches;
    }
}
