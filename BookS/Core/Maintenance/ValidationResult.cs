
namespace BookS.Core.Maintenance
{
    public enum ValidationStatus
    {
        EmptyField,
        Failed,
        InnerException,
        NullReference,
        Success,
    }

    /// <summary>
    /// This class contains information about object validation
    /// result performed using methods from IValidation interface.
    /// </summary>
    public class ValidationResult
    {
        public ValidationStatus Status { get; set; }
        public string Message { get; set; }
        public string ExceptionMessage { get; set; }
    }
}
