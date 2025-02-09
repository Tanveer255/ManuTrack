using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcessFlow.BLL.Services;

internal sealed class UserRolesService(
    IUnitOfWork unitOfWork,IUserRolesRepository userRolesRepository
    ):CrudService<UserRoles>(userRolesRepository,unitOfWork), IUserRolesService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IUserRolesRepository _userRolesRepository = userRolesRepository;
}
