namespace ProductNest.DAL.Interface
{
    public interface IInventoryRepository : IRepository<Inventory>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Inventory> GetById(Guid id);
    }
}
