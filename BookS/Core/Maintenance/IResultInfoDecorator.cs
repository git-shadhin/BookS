using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookS.Core.Maintenance
{
    public interface IResultInfoDecorator
    {
        ValidationResult ValidationResult { get; set; }

        ResultInfoDecorator WithValidationResult(ValidationResult pValidationResult);
    }
}
