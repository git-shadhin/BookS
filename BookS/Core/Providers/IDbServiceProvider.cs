
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using BookS.Core.Maintenance;
using BookS.Core.Models;

namespace BookS.Core.Providers
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDbServiceProvider<T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pFilter"></param>
        /// <param name="pRequestedObject"></param>
        /// <returns></returns>
        ResultInfo LoadFromDb(Predicate<T> pFilter, out T pRequestedObject);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pFilter"></param>
        /// <param name="pObjectsRequested"></param>
        /// <returns></returns>
        ResultInfo LoadFromDb(Predicate<T> pFilter, out List<T> pObjectsRequested);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        ResultInfo SaveToDb(T pObject);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        ResultInfo UpdateInDb(T pObject);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        ResultInfo DeleteFromDb(T pObject);
    }
}
