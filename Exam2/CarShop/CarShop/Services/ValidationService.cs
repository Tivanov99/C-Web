﻿using CarShop.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CarShop.Services
{
    public class ValidationService : IValidationService
    {
        public (bool isValid, string error) Validate(object model)
        {
            var context = new ValidationContext(model);
            var errorResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(model, context, errorResult, true);

            if (isValid)
            {
                return (isValid, null);
            }

            string error = String.Join(", ", errorResult.Select(e => e.ErrorMessage));

            return (isValid, error);
        }
    }
}
