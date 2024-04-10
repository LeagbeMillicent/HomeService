using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Application.Exceptions
{
    public class ValidationCommandException : ApplicationException
    {
        public IDictionary<string, string[]> Errors { get; }

        /* This is a constructor for the `ValidationCommandException` class that calls the default
        constructor of the `ApplicationException` base class and sets the message for the exception
        to "One or more validation failures occurred". */
        public ValidationCommandException() : base("One or more validation failures occurred")
        {

        }

        /* This is a constructor for the `ValidationCommandException` class that takes in an
        `IEnumerable` of `ValidationFailure` objects as a parameter. It calls the default constructor
        `this()` to set the base message for the exception. It then uses LINQ to group the validation
        failures by their property name and map them to an array of error messages. Finally, it
        creates a dictionary where the keys are the property names and the values are the arrays of
        error messages, and assigns it to the `Errors` property of the exception. */
        public ValidationCommandException(IEnumerable<ValidationFailure> failures) : this()
        {
            Errors = failures
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(f => f.Key, f => f.ToArray());

        }
    }
}
