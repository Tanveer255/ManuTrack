using AcessFlow.BLL.Interfaces;
using AcessFlow.Entity.DTO;

namespace AcessFlow.BLL.Services;

public sealed class ApplicationUserService(IApplicationUserRepository applicationUserRepository,
         IUnitOfWork unitOfWork,
         IHttpContextAccessor httpContextAccessor
    ) : CrudService<ApplicationUser>(applicationUserRepository,unitOfWork), IApplicationUserService
{
    private readonly IApplicationUserRepository _applicationUserRepository = applicationUserRepository;
    private readonly IUnitOfWork _unitOfWork =unitOfWork;
    private readonly HttpContext _httpContext = httpContextAccessor.HttpContext;
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
    public bool ExistUser(string email)
    {
        var exist =  _unitOfWork.Context.Users.Where(e=>e.Email.Equals(email)).FirstOrDefault();
        if (exist != null)
        {
            return true;
        }

        return false;
    }
    public async Task<ApplicationUser> GetUserByEmail(string email)
    {
        var user = await _unitOfWork.Context.Users.FindAsync(email);
        if (user== null)
            return null;
        return user;
    }
}
