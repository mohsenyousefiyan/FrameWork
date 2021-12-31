using FrameWork.Core.Domain.Contract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FrameWork.EndPoints.WebApi.ViewModels.BaseViewModels
{
    public class BaseInputModel : IValidatableModel
    {
        public string Validate()
        {
            ValidationContext context = new ValidationContext(this, serviceProvider: null, items: null);
            List<ValidationResult> results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(this, context, results, true);

            if (isValid == false)
            {
                var errors = "";
                foreach (var validationResult in results)
                    errors += validationResult.ErrorMessage + "|";

                if (errors.EndsWith("|"))
                    errors = errors.Substring(0, errors.Length - 1);

                return errors;
            }
            return null;
        }
    }
}
