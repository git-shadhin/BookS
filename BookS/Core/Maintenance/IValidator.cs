
namespace BookS.Core.Maintenance
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IValidator<in T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pInObject"></param>
        /// <returns></returns>
        ValidationResult ValidateAndAssign(T pInObject);

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
