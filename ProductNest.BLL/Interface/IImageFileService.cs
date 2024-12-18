using ProductNest.Entity;
using ProductNest.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductNest.BLL.Interface;
public interface IImageFileService : ICrudService<ImageFile>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    public Task<ImageFile> GetById(Guid Id);
    public Task<List<ImageFile>> GetAllDataAsync();
}

