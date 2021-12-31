using FrameWork.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameWork.Core.Domain.ApplicationServices.Queries
{
    public sealed class QueryResult<TData>
    {
        public bool IsSuccess { get; private set; }
        public EnuResultStatusCode StatusCode { get; private set; }
        public string ErrorMessage { get; private set; }
        public TData Result { get; private set; }

        public QueryResult(EnuResultStatusCode statuscode, bool issuccess = false, string message = null, TData result = default)
        {
            IsSuccess = issuccess;
            StatusCode = issuccess ? EnuResultStatusCode.Success : statuscode;
            ErrorMessage = message;
            Result = result;
        }


    }
}
