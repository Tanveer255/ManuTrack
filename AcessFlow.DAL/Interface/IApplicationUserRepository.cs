using AcessFlow.Entity.Entity.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
