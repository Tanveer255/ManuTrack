namespace AcessFlow.BLL.Services;

internal sealed class ManageUserRolesService(IManageUserRolesRepository manageUserRolesRepository,
     IUnitOfWork unitOfWork
    ):CrudService<ManageUserRoles>(manageUserRolesRepository, unitOfWork), IManageUserRolesService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IManageUserRolesRepository _manageUserRolesRepository = manageUserRolesRepository;
}
