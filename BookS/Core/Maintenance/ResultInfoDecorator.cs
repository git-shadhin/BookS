using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookS.Core.Maintenance
{
    public class ResultInfoDecorator : IResultInfoDecorator
    {
        public ValidationResult ValidationResult { get; set; }
        
        public ResultInfoDecorator WithValidationResult(ValidationResult pValidationResult)
        {
            if (ValidationResult == null)
            {
                ValidationResult = pValidationResult;
            }

            return this;
        }
    }
}
