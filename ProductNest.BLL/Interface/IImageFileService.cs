﻿namespace ProductNest.BLL.Interface;
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

