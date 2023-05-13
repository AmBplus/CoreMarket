﻿using System.ComponentModel.DataAnnotations;
using Base.Shared.ResultUtil;

namespace Base.Shared;

public static class ValidationHelper
{
    static ValidationHelper()
    {
    }

    public static ResultOperation GetFailedResultWithError_s(this IList<ValidationResult> validationResults)
    {
        var errors = validationResults.Select(x => x.ErrorMessage);
        return ResultOperation.BuildFailedResult(errors!);
    }

    public static bool IsValid<T>(this T entity) where T : class
    {
        var validationContext =
            new ValidationContext(instance: entity);

        var validationResults =
            new List<ValidationResult>();

        var isValid =
            Validator
                .TryValidateObject(instance: entity, validationContext: validationContext,
                    validationResults: validationResults, validateAllProperties: true);
        
        return isValid;
    }

    public static IList<ValidationResult>
        GetValidationResults<T>(this T entity) where T : class
    {
        var validationContext =
            new ValidationContext(instance: entity);

        var validationResults =
            new List<ValidationResult>();

        //var isValid =
        Validator
            .TryValidateObject(instance: entity, validationContext: validationContext,
                validationResults: validationResults, validateAllProperties: true);

        return validationResults;
    }

}
