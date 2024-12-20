﻿using Microsoft.AspNetCore.Http;
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
public class VariantService : CrudService<Variant>, IVariantService
{
    private readonly IVariantRepository _variantRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly HttpContext _httpContext;
    public VariantService(IVariantRepository variantRepository,
         IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        : base(variantRepository, unitOfWork)
    {
        _variantRepository = variantRepository;
        _unitOfWork = unitOfWork;
        _httpContext = httpContextAccessor.HttpContext;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<Variant> GetById(Guid id)
    {
        var result = await _variantRepository.GetById(id);
        return result;
    }
    public async Task<List<Variant>> GetAllDataAsync()
    {
        var result = await _unitOfWork.Context.Variants.ToListAsync();
        return result;
    }
}
