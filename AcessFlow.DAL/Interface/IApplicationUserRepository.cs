namespace AcessFlow.DAL.Interface;

public interface IApplicationUserRepository : IRepository<ApplicationUser>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<ApplicationUser> GetById(Guid id);
}
