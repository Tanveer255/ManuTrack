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
public class UnitOfMeasureService : CrudService<UnitOfMeasure>, IUnitOfMeasureService
{
    private readonly IUnitOfMeasureRepository _unitOfMeasureRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly HttpContext _httpContext;
    public UnitOfMeasureService(IUnitOfMeasureRepository unitOfMeasureRepository,
         IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        : base(unitOfMeasureRepository, unitOfWork)
    {
        _unitOfMeasureRepository = unitOfMeasureRepository;
        _unitOfWork = unitOfWork;
        _httpContext = httpContextAccessor.HttpContext;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<UnitOfMeasure> GetById(string code)
    {
        var result = await _unitOfMeasureRepository.GetById(code);
        return result;
    }
    public async Task<List<UnitOfMeasure>> GetAllDataAsync()
    {
        var result = await _unitOfWork.Context.UnitOfMeasures.ToListAsync();
        return result;
    }
}