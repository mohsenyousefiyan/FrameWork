using FrameWork.Core.Domain.ApplicationServices.Queries;
using FrameWork.Core.Domain.Exceptions;
using FrameWork.EndPoints.WebApi.InfraStructures.CustomObjectResult;
using FrameWork.EndPoints.WebApi.ViewModels.BaseViewModels;
using FrameWork.Utilities.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace FrameWork.EndPoints.WebApi.Services
{
    public class QueryRequestHandler
    {
        private readonly ILogger<QueryRequestHandler> logger;

        public QueryRequestHandler(ILogger<QueryRequestHandler> _logger)
        {
            logger = _logger;
        }

        public IActionResult HandleRequest<T, TData>(T request, Func<T, QueryResult<TData>> handler)
        {
            try
            {
                var Result = handler(request);
                return new OkObjectResult(new BaseApiResultModel(issuccess: Result.IsSuccess, statuscode: Result.StatusCode, message: Result.ErrorMessage, result: Result.Result));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.GetErrorMessage());

                if (ex.GetBaseException() is BaseException)
                    return new ValidationExceptionObjectResult(ex, ex.GetErrorMessage());


                return new BadRequestObjectResult(new
                {
                    error =
                    ex.Message,
                    stackTrace = ex.StackTrace
                });
            }
        }

    }
}
