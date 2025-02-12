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
        public bool ValidateUser(string email);
    }
}
