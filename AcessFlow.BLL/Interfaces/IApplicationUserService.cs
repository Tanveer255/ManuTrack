using AcessFlow.Entity.DTO;

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
        public bool ExistUser(string email);
        public Task<ApplicationUser> GetUserByEmail(string email);
    }
}
