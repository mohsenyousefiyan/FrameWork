using FrameWork.Core.Domain.Enums;
using FrameWork.Utilities.Helpers;

namespace FrameWork.EndPoints.WebApi.ViewModels.BaseViewModels
{
    public class BaseApiResultModel
    {
        public bool IsSuccess { get; set; }
        public EnuResultStatusCode StatusCode { get; set; }
        public string ErrorMessage { get; set; }
        public object Result { get; set; }

        public BaseApiResultModel(EnuResultStatusCode statuscode, bool issuccess = false, string message = null, object result = null)
        {
            IsSuccess = issuccess;
            Result = result;
            StatusCode = issuccess ? EnuResultStatusCode.Success : statuscode;
            ErrorMessage = message ?? StatusCode.ToDisplay();
        }
    }
}
