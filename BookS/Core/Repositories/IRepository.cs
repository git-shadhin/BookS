using System;
using System.Collections.Generic;
using BookS.Core.Maintenance;

namespace BookS.Core.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T>
    {
        ResultInfo<T> Add(T pObject);
        ResultInfo<T> Update(T pObject);
        ResultInfo<T> Remove(T pObject);
    }
}
