using ProductNest.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductNest.DAL.Interface;

public interface IBOMItemRepository : IRepository<BOMItem>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="productId"></param>
    /// <returns></returns>
    public Task<BOMItem> GetById(Guid id);
}
