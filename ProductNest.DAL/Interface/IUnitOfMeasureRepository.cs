using ProductNest.Entity;
using ProductNest.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductNest.DAL.Interface;
public interface IUnitOfMeasureRepository : IRepository<UnitOfMeasure>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    public Task<UnitOfMeasure> GetById(string code);
}
