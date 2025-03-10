﻿using AcessFlow.DAL.Interface;
using EBS.DAL.Interface;

namespace AcessFlow.BLL.Services;
public interface IManageUserRolesService : ICrudService<ManageUserRoles>
{
}

internal sealed class ManageUserRolesService(IManageUserRolesRepository manageUserRolesRepository,
     IUnitOfWork unitOfWork
    ):CrudService<ManageUserRoles>(manageUserRolesRepository, unitOfWork), IManageUserRolesService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IManageUserRolesRepository _manageUserRolesRepository = manageUserRolesRepository;
}
