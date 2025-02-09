using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcessFlow.DAL.Repository;

internal sealed class UserRolesRepository(
    IUnitOfWork unitOfWork,
    ILogger<UserRolesRepository> logger
    ) :Repository<UserRoles>(unitOfWork, logger), IUserRolesRepository
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ILogger<UserRolesRepository> _logger = logger;
}
