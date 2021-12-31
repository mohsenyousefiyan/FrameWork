using Microsoft.AspNetCore.Mvc;

namespace FrameWork.EndPoints.WebApi.InfraStructures.CustomObjectResult
{
    public class ValidationExceptionObjectResult : ObjectResult
    {
        private readonly string exceptionMessage;

        public string Error => exceptionMessage;

        public ValidationExceptionObjectResult(object value, string exceptionMessage) : base(value)
        {
            this.exceptionMessage = exceptionMessage;
        }
    }
}
