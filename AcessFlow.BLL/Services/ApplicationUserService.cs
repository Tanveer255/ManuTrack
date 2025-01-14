using AcessFlow.BLL.Interfaces;
using AcessFlow.DAL.Interface;
using AcessFlow.Entity.Entity.Identity;
using EBS.DAL.Interface;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcessFlow.BLL.Services;

public class ApplicationUserService: CrudService<ApplicationUser>, IApplicationUserService
{
    private readonly IApplicationUserRepository _applicationUserRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly HttpContext _httpContext;
    public ApplicationUserService(IApplicationUserRepository applicationUserRepository,
         IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        : base(applicationUserRepository, unitOfWork)
    {
        _applicationUserRepository = applicationUserRepository;
        _unitOfWork = unitOfWork;
        _httpContext = httpContextAccessor.HttpContext;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<ApplicationUser> GetById(Guid id)
    {
        var result = await _applicationUserRepository.GetById(id);
        return result;
    }
}
