using ProductNest.Entity;
using ProductNest.Entity.Manufacturing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductNest.BLL.Interface.Manufacturing;

public interface IBatchService : ICrudService<Batch>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="productId"></param>
    /// <returns></returns>
    public Task<Batch> GetById(Guid productId);
    public Task<List<Batch>> GetAllDataAsync();
}
