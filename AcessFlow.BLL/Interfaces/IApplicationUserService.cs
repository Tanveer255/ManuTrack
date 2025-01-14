using AcessFlow.Entity.Entity.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcessFlow.BLL.Interfaces
{
    public interface IApplicationUserService : ICrudService<ApplicationUser>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Task<ApplicationUser> GetById(Guid Id);
    }
}
