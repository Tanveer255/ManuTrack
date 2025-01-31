namespace ProductNest.DAL.Interface;

public interface IImageFileRepository : IRepository<ImageFile>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<ImageFile> GetById(Guid id);
}
