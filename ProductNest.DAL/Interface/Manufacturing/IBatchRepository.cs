using ProductNest.Entity;
using ProductNest.Entity.Manufacturing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductNest.DAL.Interface.Manufacturing;

public interface IBatchRepository : IRepository<Batch>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="batchId"></param>
    /// <returns></returns>
    public Task<Batch> GetById(Guid batchId);
}
