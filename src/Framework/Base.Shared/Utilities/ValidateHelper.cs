using Framework.Utilities.ResultUtil;
using System.ComponentModel.DataAnnotations;

namespace Framework.Utilities;

    public static class ValidationHelper
    {
        static ValidationHelper()
        {
        }

        public static ResultOperation GetFailedResultWithError_s(this IList<ValidationResult> validationResults )
        {
            var errors = validationResults.Select( x => x.ErrorMessage );
           return ResultOperation.BuildFailedResult(errors!);
        }

        public static bool IsValid<T>(this T entity)  where T : class 
        {
            var validationContext =
                new System.ComponentModel.DataAnnotations.ValidationContext(instance: entity);

            var validationResults =
                new System.Collections.Generic.List<System.ComponentModel.DataAnnotations.ValidationResult>();

            var isValid =
                System.ComponentModel.DataAnnotations.Validator
                    .TryValidateObject(instance: entity, validationContext: validationContext,
                        validationResults: validationResults, validateAllProperties: true);

            return isValid;
        }

        public static System.Collections.Generic.IList<System.ComponentModel.DataAnnotations.ValidationResult>
            GetValidationResults<T>(this T entity) where T : class
    {
            var validationContext =
                new System.ComponentModel.DataAnnotations.ValidationContext(instance: entity);

            var validationResults =
                new System.Collections.Generic.List<System.ComponentModel.DataAnnotations.ValidationResult>();

            //var isValid =
            System.ComponentModel.DataAnnotations.Validator
                .TryValidateObject(instance: entity, validationContext: validationContext,
                    validationResults: validationResults, validateAllProperties: true);

            return validationResults;
        }

    }
