using Microsoft.Extensions.Logging;
using ProductNest.DAL.Interface;
using ProductNest.Entity;
using ProductNest.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductNest.DAL.Repository;


public class ImageFileRepository : Repository<ImageFile>, IImageFileRepository
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<ImageFileRepository> _logger;
    public ImageFileRepository(IUnitOfWork unitOfWork, ILogger<ImageFileRepository> logger)
        : base(unitOfWork, logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }
    public async Task<ImageFile> GetById(Guid id)
    {
        ImageFile imageFile = new ImageFile();
        try
        {
            _logger.LogError("Getting imageFile by Id");
            imageFile = (from bom in _unitOfWork.Context.ImageFiles
                       where
                       bom.Id.Equals(id)
                       && bom.IsDeleted.Equals(false)

                       select new ImageFile
                       {
                           ImageFileId = bom.ImageFileId,
                           Alt = bom.Alt,
                           Position = bom.Position,
                           ProductId = bom.ProductId,
                           AdminGraphqlApiId = bom.AdminGraphqlApiId,
                           Width = bom.Width,
                           Height = bom.Height,
                           Src = bom.Src,
                           VariantIds = bom.VariantIds,
                       }).FirstOrDefault();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message, ex.InnerException, ex.InnerException != null ? ex.InnerException.Message : string.Empty);
            throw new Exception(ex.Message, ex.InnerException);
        }
        _logger.LogError("Returning imageFile :" + imageFile);
        return await Task.FromResult(imageFile);
    }
}
