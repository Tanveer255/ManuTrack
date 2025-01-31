namespace ProductNest.DAL.Interface.Manufacturing;
public interface ICompletedPartRepository : IRepository<CompletedPart>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<CompletedPart> GetById(Guid id);
}