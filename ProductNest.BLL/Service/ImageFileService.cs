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

public class ImageFileService : CrudService<ImageFile>, IImageFileService
{
    private readonly IImageFileRepository _imageFileRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly HttpContext _httpContext;
    public ImageFileService(IImageFileRepository imageFileRepository,
         IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        : base(imageFileRepository, unitOfWork)
    {
        _imageFileRepository = imageFileRepository;
        _unitOfWork = unitOfWork;
        _httpContext = httpContextAccessor.HttpContext;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<ImageFile> GetById(Guid id)
    {
        var result = await _imageFileRepository.GetById(id);
        return result;
    }
    public async Task<List<ImageFile>> GetAllDataAsync()
    {
        var result = await _unitOfWork.Context.ImageFiles.ToListAsync();
        return result;
    }
}
