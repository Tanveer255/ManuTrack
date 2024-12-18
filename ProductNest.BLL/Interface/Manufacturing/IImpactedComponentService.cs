using ProductNest.Entity.Manufacturing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductNest.BLL.Interface.Manufacturing;

public interface IImpactedComponentService : ICrudService<ImpactedComponent>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<ImpactedComponent> GetById(Guid id);
    public Task<List<ImpactedComponent>> GetAllDataAsync();
}
