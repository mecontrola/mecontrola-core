using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MeControla.Core.Tests.Exceptions
{
    public class FormValidationException(Type type, ValidationResult result)
        : Exception(ERROR_MESSAGE.Replace(ERROR_MESSAGE_PARAM, type.Name))
    {
        private const string ERROR_MESSAGE_PARAM = "{entityName}";
        private const string ERROR_MESSAGE = $"The {ERROR_MESSAGE_PARAM} data is not valid. Please adjust the information in the highlighted fields.";

        private readonly Dictionary<string, List<string>> propertyErrors = result.Errors
                                                                                 .GroupBy(itm => itm.PropertyName)
                                                                                 .ToDictionary(itm => itm.Key,
                                                                                               itm => itm.Select(val => val.ErrorMessage)
                                                                                                         .ToList());

        public Dictionary<string, List<string>> PropertyErrors => propertyErrors;
    }
}