

using System.ComponentModel;

namespace ProductNest.BLL.Service;

public class ImageFileService(
    IImageFileRepository imageFileRepository,
         IUnitOfWork unitOfWork,
         IHttpContextAccessor httpContextAccessor
    ) : CrudService<ImageFile>(imageFileRepository, unitOfWork), IImageFileService
{
    private readonly IImageFileRepository _imageFileRepository= imageFileRepository;
    private readonly IUnitOfWork _unitOfWork =unitOfWork;
    private readonly HttpContext _httpContext = httpContextAccessor.HttpContext;
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
    public async Task<ImageFile> AddUpdate(ImageFile file)
    {
        var result = await ImageFileExist(file.Id);
        if (result)
        {
           await _imageFileRepository.Add(file);
           _unitOfWork.Commit();
            return file;
        }
        await _imageFileRepository.Update(file);
        _unitOfWork.Commit();
        return file;
    }
    public async Task<List<ImageFile>> GetAllDataAsync()
    {
        var result = await _unitOfWork.Context.ImageFiles.ToListAsync();
        return result;
    }
    public async Task<bool> ImageFileExist(Guid id) {
        var result =await _unitOfWork.Context.ImageFiles.FindAsync(id);
        if (result != null)
            return true;
        return false;
    }
}
