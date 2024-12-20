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

public class WarehouseService : CrudService<Warehouse>, IWarehouseService
{
    private readonly IWarehouseRepository _warehouseRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly HttpContext _httpContext;
    public WarehouseService(IWarehouseRepository warehouseRepository,
         IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        : base(warehouseRepository, unitOfWork)
    {
        _warehouseRepository = warehouseRepository;
        _unitOfWork = unitOfWork;
        _httpContext = httpContextAccessor.HttpContext;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<Warehouse> GetById(Guid id)
    {
        var result = await _warehouseRepository.GetByIdAsync(id);
        return result;
    }
    public async Task<List<Warehouse>> GetAllDataAsync()
    {
        var result = await _unitOfWork.Context.Warehouse.ToListAsync();
        return result;
    }
}