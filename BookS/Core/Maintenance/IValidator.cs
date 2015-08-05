
namespace BookS.Core.Maintenance
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IValidator<in T>
    {
        ValidationResult ValidationResult { get; } 

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        ValidationResult Validate();
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pObject1"></param>
        /// <param name="pObject2"></param>
        /// <returns></returns>
        bool? Compare(T pObject1, T pObject2);
    }
}
