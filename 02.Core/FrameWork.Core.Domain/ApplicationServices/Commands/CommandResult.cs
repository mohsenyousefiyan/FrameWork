using FrameWork.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;


namespace FrameWork.Core.Domain.ApplicationServices.Commands
{
    public class CommandResult
    {
        public bool IsSuccess { get; private set; }
        public EnuResultStatusCode StatusCode { get; private set; }
        public string ErrorMessage { get; private set; }

        public CommandResult(EnuResultStatusCode statuscode, bool issuccess = false, string message = null)
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

    public sealed class CommandResult<TData> : CommandResult
    {
        public CommandResult(EnuResultStatusCode statuscode, bool issuccess = false, string message = null, TData result = default) : base(statuscode, issuccess, message)
        {
            Result = result;
        }

        public TData Result { get; private set; }
    }
}
