using ProductNest.Entity.Manufacturing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductNest.BLL.Interface.Manufacturing;
public interface ICompletedPartService : ICrudService<CompletedPart>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<CompletedPart> GetById(Guid id);
    public Task<List<CompletedPart>> GetAllDataAsync();
}
