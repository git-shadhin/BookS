using BookS.Core.Maintenance;

namespace BookS.Core.Repositories
{
    /// <summary>
    /// This interface presents basic CRUD operations for repositories.
    /// </summary>
    public interface IRepository<T>
    {
        ResultInfo<T> Add(T pObject);
        ResultInfo<T> Update(T pObject);
        ResultInfo<T> Remove(T pObject);
    }
}
