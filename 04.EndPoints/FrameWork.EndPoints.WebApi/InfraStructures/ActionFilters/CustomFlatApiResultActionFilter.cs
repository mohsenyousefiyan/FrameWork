using FrameWork.Core.Domain.Enums;
using FrameWork.EndPoints.WebApi.InfraStructures.CustomObjectResult;
using FrameWork.EndPoints.WebApi.ViewModels.BaseViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Reflection;

namespace FrameWork.EndPoints.WebApi.InfraStructures.ActionFilters
{
    public class CustomFlatApiResultActionFilter : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            var attrib = context.Controller.GetType().GetTypeInfo().GetCustomAttribute<CustomSkipFlatApiResultActionFilter>();
            if (attrib != null)
                return;


            if (context.Result is BadRequestResult badRequestResult)
            {
                var apiResult = new BaseApiResultModel(statuscode: EnuResultStatusCode.BadRequest);
                context.Result = new JsonResult(apiResult);
            }
            else if (context.Result is BadRequestObjectResult badRequestObjectResult)
            {
                var resultobject = badRequestObjectResult.Value;
                string message = "مقادیر ورودی نامعتبر است";

                try
                {
                    if (resultobject is ValidationProblemDetails problemDetails)
                    {
                        var errorMessages = problemDetails.Errors.SelectMany(p => p.Value).Distinct();
                        message = string.Join(" | ", errorMessages);
                    }
                }
                catch
                {
                }

                var apiResult = new BaseApiResultModel(statuscode: EnuResultStatusCode.BadRequest, message: message);
                context.Result = new JsonResult(apiResult);
            }
            else if (context.Result is ValidationExceptionObjectResult validationExceptionObject)
            {
                var apiResult = new BaseApiResultModel(statuscode: EnuResultStatusCode.BadRequest, message: validationExceptionObject.Error);
                context.Result = new JsonResult(apiResult);
            }
            else if (context.Result is UnauthorizedResult unauthorizedResult)
            {
                var apiResult = new BaseApiResultModel(statuscode: EnuResultStatusCode.BadRequest);
                context.Result = new JsonResult(apiResult);
            }
            else if (context.Result is NotFoundResult notFoundResult)
            {
                var apiResult = new BaseApiResultModel(statuscode: EnuResultStatusCode.NotFound);
                context.Result = new JsonResult(apiResult);
            }
            else if (context.Result is NotFoundObjectResult notFoundObjectResult)
            {
                var apiResult = new BaseApiResultModel(statuscode: EnuResultStatusCode.NotFound, result: notFoundObjectResult.Value);
                context.Result = new JsonResult(apiResult);
            }

            base.OnResultExecuting(context);
        }
    }
}
