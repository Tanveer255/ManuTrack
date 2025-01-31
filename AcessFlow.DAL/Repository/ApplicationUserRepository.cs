namespace AcessFlow.DAL.Repository;

public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<ApplicationUserRepository> _logger;
    public ApplicationUserRepository(IUnitOfWork unitOfWork, ILogger<ApplicationUserRepository> logger)
        : base(unitOfWork, logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }
    public async Task<ApplicationUser> GetById(Guid id)
    {
        var user = new ApplicationUser();
        try
        {
            _logger.LogError("Getting ApplicationUser by Id");
            user = (from use in _unitOfWork.Context.Users
                         where
                         use.Id.Equals(id)
                         //&& use.IsDeleted.Equals(false)

                         select new ApplicationUser
                         {
                             FirstName = use.FirstName,
                             LastName = use.LastName,
                             UsernameChangeLimit = use.UsernameChangeLimit,
                             Id = use.Id,
                             SecurityStamp = use.SecurityStamp,
                             UserName = use.UserName,
                             NormalizedUserName = use.NormalizedUserName,
                             Email = use.Email,
                             NormalizedEmail = use.NormalizedEmail,
                             EmailConfirmed = use.EmailConfirmed,
                             PasswordHash = use.PasswordHash,
                             ConcurrencyStamp = use.ConcurrencyStamp,
                             PhoneNumber = use.PhoneNumber,
                             PhoneNumberConfirmed = use.PhoneNumberConfirmed,
                             TwoFactorEnabled = use.TwoFactorEnabled,
                             LockoutEnd = use.LockoutEnd,
                             LockoutEnabled = use.LockoutEnabled,
                             AccessFailedCount = use.AccessFailedCount,
                         }).FirstOrDefault();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message, ex.InnerException, ex.InnerException != null ? ex.InnerException.Message : string.Empty);
            throw new Exception(ex.Message, ex.InnerException);
        }
        _logger.LogError("Returning ApplicationUser :" + user);
        return await Task.FromResult(user);
    }
}
