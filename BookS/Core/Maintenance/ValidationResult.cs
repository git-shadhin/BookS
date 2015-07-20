
namespace BookS.Core.Maintenance
{
    /// <summary>
    /// 
    /// </summary>
    public class ValidationResult
    {
        public enum ValidationStatus
        {
            Failed,
            NullReference,
            MethodException,
            Success,
        }

        public ValidationStatus Status { get; set; }
        public string Message { get; set; }
    }
}
