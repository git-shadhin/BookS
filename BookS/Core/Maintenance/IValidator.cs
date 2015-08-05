
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
    }
}
