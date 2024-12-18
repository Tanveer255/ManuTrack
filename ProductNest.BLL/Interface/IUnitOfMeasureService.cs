using ProductNest.Entity;
using ProductNest.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductNest.BLL.Interface;
public interface IUnitOfMeasureService : ICrudService<UnitOfMeasure>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    public Task<UnitOfMeasure> GetById(string code);
    public Task<List<UnitOfMeasure>> GetAllDataAsync();
}