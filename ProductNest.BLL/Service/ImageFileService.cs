

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
    public async Task<List<ImageFile>> GetAllDataAsync()
    {
        var result = await _unitOfWork.Context.ImageFiles.ToListAsync();
        return result;
    }
}
