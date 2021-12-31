using FrameWork.Core.Domain.Enums;

namespace FrameWork.Core.Domain.Dtos.CommonDto
{
    public class ServiceResult
    {
        public bool IsSuccess { get; private set; }
        public EnuResultStatusCode StatusCode { get; private set; }
        public string ErrorMessage { get; private set; }

        public ServiceResult(EnuResultStatusCode statuscode, bool issuccess = false, string message = null)
        {
            if (statuscode != EnuResultStatusCode.Success)
                issuccess = false;

            if (statuscode == EnuResultStatusCode.Success)
                issuccess = true;

            IsSuccess = issuccess;
            StatusCode = issuccess ? EnuResultStatusCode.Success : statuscode;
            ErrorMessage = message;
        }
    }

    public sealed class ServiceResult<TData> : ServiceResult
    {
        public ServiceResult(EnuResultStatusCode statuscode, bool issuccess = false, string message = null, TData result = default) : base(statuscode, issuccess, message)
        {
            Result = result;
        }

        public TData Result { get; private set; }
    }
}
